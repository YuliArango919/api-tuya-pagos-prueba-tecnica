using Newtonsoft.Json;

namespace App.Tuya.Pagos.Common.Utils
{
    public static class UtilTy
    {
        public static T Deserialize<T>(this string jsonString) where T : class
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        public static string Serialize<T>(this T Obj) where T : class
        {
            return JsonConvert.SerializeObject(Obj);
        }
    }
}
