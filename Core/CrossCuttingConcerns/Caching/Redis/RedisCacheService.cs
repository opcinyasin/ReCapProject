﻿using Microsoft.Extensions.Options;
using ServiceStack.Redis;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheService : IRedisCacheService
    {
        #region Fields

        private readonly RedisEndpoint conf = null;

        #endregion

        public RedisCacheService()
        {

            conf = new RedisEndpoint { Host = "127.0.0.1", Port = 6379, Password = "", RetryTimeout = 1000 };
            //conf = new RedisEndpoint { Host = _devnotConfig.Value.RedisEndPoint, Port = _devnotConfig.Value.RedisPort, Password = "" };
        }
        public T Get<T>(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    var result= client.Get<T>(key);
                    return result;
                }
            }
            catch
            {
                //throw new RedisNotAvailableException();
                return default;
            }
        }



        public IList<T> GetAll<T>(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    var keys = client.SearchKeys(key);
                    if (keys.Any())
                    {
                        IEnumerable<T> dataList = client.GetAll<T>(keys).Values;
                        return dataList.ToList();
                    }
                    return new List<T>();
                }
            }
            catch
            {

                throw new Exception();
            }
        }

        public void Set(string key, object data)
        {
            Set(key, data, DateTime.Now.AddMinutes(60));
        }

        public void Set(string key, object data, DateTime time)
        {
            try
            {
                //RedisInvoker(x => x.Add(key, data, TimeSpan.FromMinutes(duration)));
                using (IRedisClient client = new RedisClient(conf))
                {
                //    var dataSerialize = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                //    {
                //        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                //    });
                    client.Set(key, data, time);
                }
            }
            catch
            {
                //throw new RedisNotAvailableException();                
            }
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    client.SetAll(values);
                }
            }
            catch
            {

                throw new Exception();
            }

        }

        public int Count(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    return client.SearchKeys(key).Where(s => s.Contains(":") && s.Contains("Mobile-RefreshToken")).ToList().Count;
                }
            }
            catch
            {

                throw new Exception();
            }
        }

        public bool IsSet(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    return client.ContainsKey(key);
                }
            }
            catch
            {

                throw new Exception();
            }
        }

        public void Remove(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    client.Remove(key);
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public void RemoveByPattern(string pattern)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    var keys = client.SearchKeys(pattern);
                    client.RemoveAll(keys);
                }
            }
            catch
            {

                throw new Exception();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object Get(string key, Type type)
        {
            var json = Get<string>(key);
            var result = JsonSerializer.DeserializeFromString(json, type);

            //return typeof(Task)
            //  .GetMethod(nameof(Task.FromResult))
            //.MakeGenericMethod(type)
            ///.Invoke(this, new object[] { result });
            ///
            return result;
        }

        public void Set(string key, dynamic data, int duration, Type type)
        {
            var json = JsonSerializer.SerializeToString(data, type);
            Set(key, json);
            
        }

        public void Set(string key, dynamic data, Type type)
        {
            var json = JsonSerializer.SerializeToString(data, type);
            Set(key, json);
        }
    }
}
