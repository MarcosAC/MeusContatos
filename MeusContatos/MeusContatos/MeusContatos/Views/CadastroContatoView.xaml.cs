using MeusContatos.Models;
using MeusContatos.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusContatos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroContatoView : ContentPage
    {
        public CadastroContatoView()
        {
            InitializeComponent();

            BindingContext = new ContatoViewModel();
        }
    }
}