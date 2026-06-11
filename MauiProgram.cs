using BlazorHybridTP4.Services; 
using Microsoft.Extensions.Logging;

namespace BlazorHybridTP4
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            // Registramos el HttpClient para nuestro servicio de Platzi
            builder.Services.AddSingleton<HttpClient>(
                sp =>
                {
                    var handler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };
                    return new HttpClient(handler)
                    {
                        BaseAddress = new Uri("https://api.escuelajs.co/api/v1/")
                    };
                });

            // Registramos nuestro servicio usando la interfaz
            builder.Services.AddSingleton<IProductService, ProductService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}