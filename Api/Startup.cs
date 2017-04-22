using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Api;
using Api.Configuration;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutomapperConfiguration.Load();
            var kernel = new StandardKernel(new NinjectConfiguration());
            var httpConfiguration = new HttpConfiguration();
            var cors = new EnableCorsAttribute("*", "*", "*");
            httpConfiguration.EnableCors(cors);
            ConfigureFormatter(httpConfiguration);
            // Web API routes
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.Routes.MapHttpRoute("DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional});

            app.UseNinjectMiddleware(() => kernel).UseNinjectWebApi(httpConfiguration);
        }

        private void ConfigureFormatter(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Formatters.Clear();
            // Only json formatter for api
            httpConfiguration.Formatters.Add(new JsonMediaTypeFormatter());

            httpConfiguration.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver(),
                    Formatting = Formatting.Indented
                };
        }
    }
}