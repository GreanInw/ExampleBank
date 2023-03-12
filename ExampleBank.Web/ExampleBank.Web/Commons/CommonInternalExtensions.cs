using System.Text;

namespace ExampleBank.Web.Commons
{
    public static class CommonInternalExtensions
    {
        public static string EncodeToBase64(this string value)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));

        public static string DecodeToBase64(this string value)
            => Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }
}
