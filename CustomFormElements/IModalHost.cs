using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TransparentModal.CustomFormElements
{
    public interface IModalHost
    {
		Task DisplayPageModal(Page page);

        Task DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
    }
}

