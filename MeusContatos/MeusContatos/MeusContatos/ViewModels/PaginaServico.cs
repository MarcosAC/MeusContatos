using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeusContatos.ViewModels
{
    public class PaginaServico : IPaginaServico
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await App.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task PushAsync(Page page)
        {
            await App.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
