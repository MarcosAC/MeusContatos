using MeusContatos.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusContatos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaDeContatosView : ContentPage
	{
		public ListaDeContatosView()
		{
			InitializeComponent();

            BindingContext = new ListaDeContatosViewModel();
        }

        private void OnItemSelectedContato(object sender, SelectedItemChangedEventArgs e)
        {
            LstDeContatos.SelectedItem = null;
        }
    }
}