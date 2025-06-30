using Microsoft.Extensions.Logging;
using Proyecto3_pago.ViewModels;
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

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<TransactionViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AddTransaction>();

		return builder.Build();
	}
}
