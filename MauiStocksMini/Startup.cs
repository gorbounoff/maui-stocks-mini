using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using DevExpress.Maui.CollectionView;
using DevExpress.Maui.Charts;

[assembly: XamlCompilationAttribute(XamlCompilationOptions.Compile)]

namespace DevExpress.Maui.Demo.Stocks
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.UseMauiApp<App>()
				.ConfigureMauiHandlers((_, handlers) => handlers.AddHandler<IDXCollectionView, DXCollectionViewHandler>())
				.ConfigureMauiHandlers((_, handlers) => handlers.AddHandler<ChartView, ChartViewHandler>())
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});
		}
	}
}