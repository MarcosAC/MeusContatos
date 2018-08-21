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

            ViewModel = new ListaDeContatosViewModel();
        }

        public ListaDeContatosViewModel ViewModel
        {
            get { return BindingContext as ListaDeContatosViewModel; }
            set { BindingContext = value; }
        }

        private void OnItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                ViewModel.SelecionarContatoCommand.Execute(e.SelectedItem);

            listViewContatos.SelectedItem = null;
        }
    }
}