using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public interface IRedisCacheService
    {
        object Get(string key, Type type);
        void Set(string key, object data, int duration, Type type);
        void Set(string key, object data, Type type);
        T Get<T>(string key);
        IList<T> GetAll<T>(string key);
        void Set(string key, object data);
        void Set(string key, object data, DateTime time);
        void SetAll<T>(IDictionary<string, T> values);
        bool IsSet(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        void Clear();
        int Count(string key);

    }
}
