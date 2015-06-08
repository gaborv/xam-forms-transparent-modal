using System;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace  TransparentModal.CustomFormElements
{
    public class ModalHostPage : ContentPage, IModalHost
    {
        #region IModalHost implementation

        public Task DisplayPageModal(Page page)
        {
            var displayEvent = DisplayPageModalRequested;

            Task completion = null;
            if (displayEvent != null)
            {
                var eventArgs = new DisplayPageModalRequestedEventArgs(page);
                displayEvent(this, eventArgs);
                completion = eventArgs.DisplayingPageTask;
            }

            // If there is not task, just create a new completed one
            return completion ?? Task.FromResult<object>(null);
        }
//
//        public Task IModalHost.DisplayAlert(string title, string message, string cancel) => base.DisplayAlert(title, message, cancel);
//        public Task<bool> IModalHost.DisplayAlert(string title, string message, string accept, string cancel) => base.DisplayAlert(title, message, accept, cancel);
//        public Task<string> IModalHost.DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons) => base.DisplayActionSheet(title, cancel, destruction, buttons);
//
        #endregion

        public event EventHandler<DisplayPageModalRequestedEventArgs> DisplayPageModalRequested;

        public sealed class DisplayPageModalRequestedEventArgs : EventArgs
        {
            public Task DisplayingPageTask { get; set;}

            public Page PageToDisplay { get; }

            public DisplayPageModalRequestedEventArgs(Page modalPage)
            {
                PageToDisplay = modalPage;
            }
        }
    }
}


