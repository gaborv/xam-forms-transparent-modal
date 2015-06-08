using System;

using Xamarin.Forms;
using TransparentModal.Pages;

namespace TransparentModal
{
	public class App : Application
	{
		public App ()
		{ 
			// Setup page navigation
			var navigationPage = new NavigationPage();
			navigationPage.PushAsync(new FirstPage(), false);

			MainPage = navigationPage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

