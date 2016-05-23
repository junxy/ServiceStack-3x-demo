using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using ServiceStack3x_01.Services;
using System;

namespace ServiceStack3x_01
{
    public class Global : System.Web.HttpApplication
    {
        public class HelloAppHost : AppHostBase
        {
            //Tell Service Stack the name of your application and where to find your web services
            public HelloAppHost() : base("Hello Web Services", typeof(HelloService).Assembly) { }

            public override void Configure(Funq.Container container)
            {
                //register any dependencies your services use, e.g:
                //container.Register<ICacheClient>(new MemoryCacheClient());

                //Set JSON web services to return idiomatic JSON camelCase properties
                ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
                //Change the default ServiceStack configuration
                Feature disableFeatures = Feature.Jsv | Feature.Soap | Feature.Xml | Feature.Csv;
                SetConfig(new EndpointHostConfig
                {
                    EnableFeatures = Feature.All.Remove(disableFeatures), //all formats except of JSV and SOAP
                    DebugMode = true, //Show StackTraces in service responses during development
                    WriteErrorsToResponse = false, //Disable exception handling
                    DefaultContentType = ContentType.Json, //Change default content type
                    AllowJsonpRequests = true //Enable JSONP requests
                });
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new HelloAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}