using StackExchange.Redis;
using System.Text.Json;

namespace ConcorrenciaNews.Helpers
{
    public static class RedisHelpers
    {

        public static void SetData(this IDatabase db, string key, object data)
        {
            SetData(db, key, data, TimeSpan.FromSeconds(5));
        }

        public static void SetData(this IDatabase db, string key, object data, TimeSpan? ttl)
        {
            db.StringSet(key, JsonSerializer.Serialize(data), ttl);
        }

        public static T? GetData<T>(this IDatabase db, string key)
        {
            var res = db.StringGet(key);
            if (res.IsNull) return default;

            return JsonSerializer.Deserialize<T>(res);
        }
    }
}