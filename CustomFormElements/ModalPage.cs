using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  TransparentModal.CustomFormElements
{
	public class ModalPage : ContentPage
    {
        public Task Close()
        {
            var displayEvent = CloseModalRequested;

            Task completion = null;
            if (displayEvent != null)
            {
                var eventArgs = new CloseModalRequestedEventArgs();
                displayEvent(this, eventArgs);
                completion = eventArgs.ClosingPageTask;
            }

            // If there is no task, just create a new completed one
            return completion ?? Task.FromResult<object>(null);
        }

        public event EventHandler<CloseModalRequestedEventArgs> CloseModalRequested;

        public sealed class CloseModalRequestedEventArgs : EventArgs
        {
            public Task ClosingPageTask { get; set; }
        }
    }
}

