using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Windows.Input;
using TransparentModal.CustomFormElements;

namespace TransparentModal.Pages
{
	public partial class PopUpPage : ModalPage
    {

        ICommand CloseCommand { get; }

		public PopUpPage()
        {
            InitializeComponent();

			// Close this pop-up using the cutom mechanis on ModalPageRenderer
			CloseCommand = new Command(() => Close());

            Shadow1.GestureRecognizers.Add(new TapGestureRecognizer{ Command = CloseCommand });
            Shadow2.GestureRecognizers.Add(new TapGestureRecognizer{ Command = CloseCommand });
            Shadow3.GestureRecognizers.Add(new TapGestureRecognizer{ Command = CloseCommand });
            Shadow4.GestureRecognizers.Add(new TapGestureRecognizer{ Command = CloseCommand });
        }

    }
}

