using CommunityToolkit.Maui;
using GestureSample.Maui.Data;
using MR.Gestures;

namespace GestureSample.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
         /*   .UseSentry(options =>
        {
            // The DSN is the only required setting.
            options.Dsn = "https://5da960cf63a94e41825ca37c8cf77012@o4505471079481344.ingest.sentry.io/4505471167954944";

            // Use debug mode if you want to see what the SDK is doing.
            // Debug messages are written to stdout with Console.Writeline,
            // and are viewable in your IDE's debug console or with 'adb logcat', etc.
            // This option is not recommended when deploying your application.
            options.Debug = true;

            // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
            // We recommend adjusting this value in production.
            options.TracesSampleRate = 1.0;

            // Other Sentry options can be set here.
        })*/
            
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			//.ConfigureMRGestures("ALZ9-BPVU-XQ35-CEBG-5ZRR-URJQ-ED5U-TSY8-6THP-3GVU-JW8Z-RZGE-CQW6");        // GestureSample
			.ConfigureMRGestures("NDTK-G7T7-QBLH-B48D-CKGP-F2NP-CV2N-B4M3-BXUR-WGQA-PLNK-BZVD-ZVCY");       // GestureSample.Maui

        string dbpath = Path.Combine(FileSystem.AppDataDirectory,"States.db");
        builder.Services.AddSingleton(s=> ActivatorUtilities.CreateInstance<StateConnection>(s,dbpath));

		return builder.Build();
	}
}
