using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private IRedisCacheService _cachemanager;
        private string _key;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cachemanager = ServiceTool.ServiceProvider.GetService<IRedisCacheService>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodname = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodname}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<null>"))})";
            var returnType = invocation.Method.ReturnType;

            if (_cachemanager.IsSet(key))
            {
                invocation.ReturnValue = _cachemanager.Get(key,returnType);
                //string a = _cachemanager.Get<string>(_key);
                //MethodInfo method = typeof(JsonConvert).GetMethods().FirstOrDefault(m => m.Name == "DeserializeObject" & m.IsGenericMethod == true);

                //MethodInfo generic = method.MakeGenericMethod(invocation.Method.ReturnParameter.ParameterType);
                //invocation.ReturnValue = generic.Invoke(this, new object[] { a });
                return;
            }
            invocation.Proceed();
            _cachemanager.Set(key, invocation.ReturnValue, _duration,returnType);
        }



        //public CacheAspect(int duration = 60, string key = "")
        //{
        //    _duration = duration;
        //    _cachemanager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        //    _key = key;

        //}

        //public override void Intercept(IInvocation invocation)
        //{

        //    var returnType = invocation.Method.ReturnParameter.ParameterType;


        //    var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

        //    var arguments = invocation.Arguments.ToList();
        //    _key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";


        //    if (_cachemanager.IsAdd(_key))
        //    {

        //        string a = _cachemanager.Get<string>(_key);
        //        MethodInfo method = typeof(JsonConvert).GetMethods().FirstOrDefault(m => m.Name == "DeserializeObject" & m.IsGenericMethod == true);

        //        MethodInfo generic = method.MakeGenericMethod(invocation.Method.ReturnParameter.ParameterType);
        //        invocation.ReturnValue = _cachemanager.Get<string>(_key);


        //        return;
        //    }
        //    invocation.Proceed();

        //    _cachemanager.Add(_key, invocation.ReturnValue, _duration);
        //}
       
    }
}
