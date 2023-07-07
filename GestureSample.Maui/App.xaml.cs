using GestureSample.Maui.Data;
using GestureSample.Views;

namespace GestureSample.Maui;

public partial class App : Application
{
	public static NavigationPage MainNavigation;

	public static StateConnection CurrentDB { get; private set; }

	public App(StateConnection currentDB)
	{
		InitializeComponent();

		var mainPage = new MainPage("Control Categories", null);
		MainPage = MainNavigation = new NavigationPage(mainPage);

		CurrentDB = currentDB;
	}
}
