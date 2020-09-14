using System;
using System.Collections.Generic;
using System.Linq;
using HakanArtucObilet.Business.Abstract;
using HakanArtucObilet.Core.Utilities;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;
using HakanArtucObilet.Web.Extensions;
using HakanArtucObilet.Web.Helpers;
using HakanArtucObilet.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace HakanArtucObilet.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILocationService _locationService;
        private readonly IJourneyService _journeyService;
        private readonly IConfiguration _configuration;

        public HomeController(IAuthService authService, ILocationService locationService,
            IJourneyService journeyService, IConfiguration configuration)
        {
            _authService = authService;
            _locationService = locationService;
            _journeyService = journeyService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            SetBusLocationData();

            //varsa cookie den al yoksa yeni model oluştur
            var model = HttpContext.GetCookieObjectFromJson<IndexViewModel>(ConstValues.COOKIE_LAST_JOURNEY) ?? new IndexViewModel
            {
                DepartureDate = DateTime.Now.AddDays(1)//yeni oluştururken bugün+1 olarak gönder.
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = GetModelStateErros(ModelState);
                SetBusLocationData();

                return View(model);
            }

            //Model validasyonundan hatasız geçmiş ise isteği daha sonraki girişler için cookie kaydet.
            HttpContext.SetCookieObjectAsJson(ConstValues.COOKIE_LAST_JOURNEY, model);

            return RedirectToAction("Journey",
                new
                {
                    originId = model.OriginId,
                    destinationId = model.DestinationId,
                    departureDate = model.DepartureDate.ToString("yyyy-MM-dd")
                });
        }

        [Route("journey/{originId}/{destinationId}/{departureDate}")]
        public IActionResult Journey(int originId, int destinationId, DateTime departureDate)
        {
            //sayfaya gelen veriler ile sorgulama yapıp gelen veriyi view a gönderir.
            var busJourneys = GetBusJourneys(originId, destinationId, departureDate);
            var model = new JourneyViewModel
            {
                DepartureDate = departureDate,
                Destination = busJourneys.FirstOrDefault()?.DestinationLocation,
                Origin = busJourneys.FirstOrDefault()?.OriginLocation,
                Journeys = busJourneys.Select(t => t.Journey).Select(t => new JourneyList
                {
                    ArrivalDate = t.Arrival,
                    DepartureDate = t.Departure,
                    Destination = t.Destination,
                    Origin = t.Origin,
                    Price = t.InternetPrice

                }).OrderBy(t => t.DepartureDate).ToList()

            };

            return View(model);
        }


        [HttpPost]
        public IActionResult BusLocations([FromBody] BusLocationSearchModel data)
        {
            //Index ekranından kalkış-varış inputlarından yapılan arama sonucunu sorgulayıp json olarak geri gönderir.
            var busLocations = GetBusLocations(data.Text);
            return Json(busLocations.Select(t => new { t.Id, t.Name }).ToList());
        }

        /// <summary>
        /// Action lara yapılan isteklerde ModelState nesnesinde hata var ise o hataları string list olarak geri gönderir.
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        private List<string> GetModelStateErros(ModelStateDictionary modelState)
        {
            return
                ModelState.Values.Where(E => E.Errors.Count > 0)
                    .SelectMany(E => E.Errors)
                    .Select(E => E.ErrorMessage)
                    .ToList();
        }

        /// <summary>
        /// Açılmış bir session varsa onu döndürür yoksa,
        /// İlgili apiye istek yaparak yeni session değerlerini alıp yeni session açar ve geri döndürür.
        /// </summary>
        /// <returns></returns>
        private Session GetSession()
        {
            //mevcutta session varsa al geri gönder.
            var session = HttpContext.Session.GetObjectFromJson<Session>(ConstValues.SESSION_API_KEY);
            if (session != null)
                return session;

            //session yoksa api isteği için nesne oluşturur.
            var sessionDto = new GetSessionDto
            {
                Type = _configuration.GetSection("SessionSettings:Type").Value.ToInt(),
                Connection = new Connection { IpAddress = _configuration.GetSection("SessionSettings:Connection:IpAddress").Value },
                Application = new Application
                {
                    EquipmentId = _configuration.GetSection("SessionSettings:Application:EquipmentId").Value,
                    Version = _configuration.GetSection("SessionSettings:Application:Version").Value
                }
            };

            //apiden session bilgisini al
            session = _authService.GetSession(sessionDto).Data;

            //yeni session bilgisini tut.
            HttpContext.Session.SetObjectAsJson(ConstValues.SESSION_API_KEY, session);

            return session;
        }

        /// <summary>
        /// Apiden BusLocations için sorgulama yapar. Parametre ile değer geçildiyse o değere göre yoksa tamamını döner.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private List<BusLocation> GetBusLocations(string location)
        {
            var busLocationDto = new GetBusLocationDto
            {
                Location = location,
                DeviceSession = GetDeviceSession()
            };

            var busLocations = _locationService.GetBusLocations(busLocationDto);
            return busLocations.Success ? busLocations.Data.ToList() : new List<BusLocation>();
        }

        /// <summary>
        /// Girilen parametrelere göre mümkün olan seyahat bilgilerini döndürür.
        /// </summary>
        /// <param name="originId"></param>
        /// <param name="destinationId"></param>
        /// <param name="departureDate"></param>
        /// <returns></returns>
        private List<BusJourneys> GetBusJourneys(int originId, int destinationId, DateTime departureDate)
        {
            var busJourneyDto = new GetBusJourneyDto()
            {
                OriginId = originId,
                DestinationId = destinationId,
                DepartureDate = departureDate,
                DeviceSession = GetDeviceSession()
            };

            var busJourneys = _journeyService.GetBusJourneys(busJourneyDto);
            return busJourneys.Success ? busJourneys.Data.ToList() : new List<BusJourneys>();
        }

        /// <summary>
        /// Apiden sorgulama yaparak BusLocations bilgilerini alır ve ViewBag.BusLocations nesnesine doldurur.
        /// </summary>
        private void SetBusLocationData()
        {
            var busLocations = GetBusLocations("");

            ViewBag.BusLocations = busLocations
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() })
                .ToList();
        }

        /// <summary>
        /// Api sorgulamalarında kullanılacak olcak DeviceSession nesnesini döndürür.
        /// </summary>
        /// <returns></returns>
        private DeviceSession GetDeviceSession()
        {
            var session = GetSession();
            return new DeviceSession
            {
                DeviceId = session.DeviceId,
                SessionId = session.SessionId
            };
        }
    }
}