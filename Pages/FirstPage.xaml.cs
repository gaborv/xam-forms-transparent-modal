using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TransparentModal.Pages
{
	public partial class FirstPage : ContentPage
	{
		public FirstPage ()
		{
			InitializeComponent ();

			Title = "First page";

			// Uncomment this to hide navigation bar
			//NavigationPage.SetHasNavigationBar(this, false);

			btnNextPage.Clicked += async (sender, e) => {
				Navigation.PushAsync (new SecondPage ());
			};
		}
	}
}

