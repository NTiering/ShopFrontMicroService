namespace ShopFront.Api.ProdCat.Ext
{
    public static class StringExt
    {
        public static int ToInt(this string s, int defaultValue)
        {
            var result = int.TryParse(s, out int intValue) ? intValue : defaultValue;
            return result;
        }
    }
}