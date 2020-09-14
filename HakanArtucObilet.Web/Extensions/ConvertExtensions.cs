namespace HakanArtucObilet.Web.Extensions
{
    /// <summary>
    /// Object convert işlemlerinin yapıldığı class.
    /// </summary>
    public static class ConvertExtensions
    {
        /// <summary>
        /// Gelen değeri int e çevirip döndürür.
        /// Null ise 0 döner.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this object value)
        {
            if (value == null)
                return 0;


            int.TryParse(value.ToString(), out int intValue);

            return intValue;
        }
    }
}
