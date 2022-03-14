using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
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
        private ICacheManager _cachemanager;
        private string _key;

        //public cacheaspect(int duration = 60)
        //{
        //    _duration = duration;
        //    _cachemanager = servicetool.serviceprovider.getservice<ıcachemanager>();
        //}

        //public override void ıntercept(ıınvocation invocation)
        //{
        //    var methodname = string.format($"{invocation.method.reflectedtype.fullname}.{invocation.method.name}");
        //    var arguments = invocation.arguments.tolist();
        //    var key = $"{methodname}({string.join(",", arguments.select(x => x?.tostring() ?? "<null>"))})";
        //    if (_cachemanager.ısadd(key))
        //    {
        //        invocation.returnvalue = _cachemanager.get(key);
        //        return;
        //    }
        //    invocation.proceed();
        //    _cachemanager.add(key, invocation.returnvalue, _duration);
        //}



        public CacheAspect(int duration = 60, string key = "")
        {
            _duration = duration;
            _cachemanager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            _key = key;

        }

        public override void Intercept(IInvocation invocation)
        {

            var returnType = invocation.Method.ReturnParameter.ParameterType;
            if (string.IsNullOrEmpty(_key))
            {
                var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

                var arguments = invocation.Arguments.ToList();
                _key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            }
            if (_cachemanager.IsAdd(_key))
            {

                string a = _cachemanager.Get<string>(_key);
                MethodInfo method = typeof(JsonConvert).GetMethods().FirstOrDefault(m => m.Name == "DeserializeObject" & m.IsGenericMethod == true);

                MethodInfo generic = method.MakeGenericMethod(invocation.Method.ReturnParameter.ParameterType);
                invocation.ReturnValue = generic.Invoke(this, new object[] { a });

                return;
            }
            invocation.Proceed();

            _cachemanager.Add(_key, ToJson(invocation.ReturnValue), _duration);
        }
        private string ToJson(object obj)
        {

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                StringEscapeHandling = StringEscapeHandling.EscapeHtml
            };
            return JsonConvert.SerializeObject(obj, Formatting.None, jsonSerializerSettings);//.Replace('"', '\'');


        }
    }
}
