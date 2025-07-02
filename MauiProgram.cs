using Microsoft.Extensions.Logging;
using Proyecto3_pago.ViewModels;
using Proyecto3_pago.DataBases;

namespace Proyecto3_pago;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Logging.AddDebug();

        builder.Services.AddSingleton<TransaccionesViewModel>();
        builder.Services.AddSingleton<UserInfoViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AddTransaction>();
        builder.Services.AddSingleton<TransactionDatabase>();

        return builder.Build();
    }
}
