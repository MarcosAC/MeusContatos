using MeusContatos.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusContatos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdicionarContatoView : ContentPage
	{
		public AdicionarContatoView ()
		{
			InitializeComponent ();

            BindingContext = new AdicionarContatoViewModel();
		}
	}
}