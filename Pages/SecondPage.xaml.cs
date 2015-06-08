using System;
using System.Collections.Generic;

using Xamarin.Forms;
using TransparentModal.CustomFormElements;

namespace TransparentModal.Pages
{
	public partial class SecondPage : ModalHostPage
	{
		public SecondPage ()
		{
			InitializeComponent ();

			Title = "Second page";

			// Uncomment this to hide navigation bar
			//NavigationPage.SetHasNavigationBar(this, false);

			btnNextPage.Clicked += async (sender, e) => {

				// Display a modal page using the custom mechanism on ModalHostPageRenderer
				await DisplayPageModal(new PopUpPage());
			};

			btnPrevPage.Clicked += async (sender, e) => {

				// Pop this page using Xamarin Forms navigation stack
				await Navigation.PopAsync();
			};
		}
	}
}

