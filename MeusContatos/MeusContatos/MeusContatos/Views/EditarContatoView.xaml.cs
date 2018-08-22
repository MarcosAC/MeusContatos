using MeusContatos.Models;
using MeusContatos.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusContatos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarContatoView : ContentPage
	{   
		public EditarContatoView (Contato contatoSelecionado)
		{
            InitializeComponent();

            BindingContext = new EditarContatoViewModel(contatoSelecionado);
		}
	}
}