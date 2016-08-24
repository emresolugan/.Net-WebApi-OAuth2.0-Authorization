using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using Owin.Security.Providers.GitHub;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Bus_Staj.App_Start;

[assembly: OwinStartup(typeof(Bus_Staj.Startup))]
namespace Bus_Staj
{
    // Servis çalışmaya başlarken Owin pipeline'ını ayağa kaldırabilmek için Startup'u hazırlıyoruz.
    public class Startup
    {

        public void Configuration(IAppBuilder appBuilder)
        {
            ConfigureOAuth(appBuilder);
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            appBuilder.UseWebApi(httpConfiguration);
            
        }

        private void ConfigureOAuth(IAppBuilder appBuilder)
        {
            OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"), // token alacağımız path'i belirtiyoruz
                AuthorizeEndpointPath = new PathString("/api/Values/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
                Provider = new Bus_Staj.App_Start.SimpleAuthorizationServerProvider()
            };

            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
                Provider = new CookieAuthenticationProvider { }
            });
            // AppBuilder'a token üretimini gerçekleştirebilmek için ilgili authorization ayarlarımızı veriyoruz.
            appBuilder.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);

            // Authentication type olarak ise Bearer Authentication'ı kullanacağımızı belirtiyoruz.
            // Bearer token OAuth 2.0 ile gelen standartlaşmış token türüdür.
            // Herhangi kriptolu bir veriye ihtiyaç duymadan client tarafından token isteğinde bulunulur ve server belirli bir expire date'e sahip bir access_token üretir.
            // Bearer token üzerinde güvenlik SSL'e dayanır.
            // Bir diğer tip ise MAC token'dır. OAuth 1.0 versiyonunda kullanılıyor, hem client'a, hemde server tarafına implementasyonlardan dolayı ek maliyet çıkartmaktadır. Bu maliyetin yanı sıra ise Bearer token'a göre kaynak alış verişinin biraz daha güvenli olduğu söyleniyor çünkü client her request'inde veriyi hmac ile imzalayıp verileri kriptolu bir şekilde göndermeleri gerektiği için.
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            appBuilder.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            appBuilder.UseGitHubAuthentication(
            clientId: "e5fbc9756d83644f38f6",
            clientSecret: "39b99e0b7edd21f9c053c2cf49287e8cbf5a8921");


        }
    }
}