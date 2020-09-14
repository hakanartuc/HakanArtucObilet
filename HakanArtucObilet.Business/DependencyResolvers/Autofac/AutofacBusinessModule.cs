using Autofac;
using HakanArtucObilet.Business.Abstract;
using HakanArtucObilet.Business.Concrete;
using HakanArtucObilet.DataAccess.Abstract;
using HakanArtucObilet.DataAccess.Concrete.HttpRequest;

namespace HakanArtucObilet.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<LocationManager>().As<ILocationService>();
            builder.RegisterType<JourneyManager>().As<IJourneyService>();

            builder.RegisterType<HrSessionDal>().As<ISessionDal>();
            builder.RegisterType<HrLocationDal>().As<ILocationDal>();
            builder.RegisterType<HrJourneyDal>().As<IJourneyDal>();

        }
    }
}
