using MeusContatos.BD.Repositorio;
using MeusContatos.Models;
using MeusContatos.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeusContatos.ViewModels
{
    public class EditarContatoViewModel : BaseViewModel
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public Contato _dadosContato;

        public Command EditarContatoCommand { get; }

        public EditarContatoViewModel(Contato contatoSelecionado)
        {
            _contatoRepositorio = new ContatoRepositorio();

            _dadosContato = contatoSelecionado;

            EditarContatoCommand = new Command(async () => await ExecuteEditarContatoCommand());
        }
        
        public string NomeContato
        {
            get { return _dadosContato.NomeContato; }
            set
            {
                _dadosContato.NomeContato = value;
                OnPropertyChanged();
            }
        }

        public string Celular
        {
            get { return _dadosContato.Celular; }
            set
            {
                _dadosContato.Celular = value;
                OnPropertyChanged();
            }
        }
        
        public string TelefoneFixo
        {
            get { return _dadosContato.TelefoneFixo; }
            set
            {
                _dadosContato.TelefoneFixo = value;
                OnPropertyChanged();
            }
        }

        private async Task ExecuteEditarContatoCommand()
        {
            bool contatoAceito = await App.Current.MainPage.DisplayAlert("Editar Contato", "Deseja editar Contato?", "Sim", "Não");

            if (contatoAceito)
            {
                try
                {
                    _contatoRepositorio.EditarContato(_dadosContato);
                    await Application.Current.MainPage.DisplayAlert("", "Contato editado com sucesso.", "Ok");
                }
                catch (Exception Erro)
                {
                    await Application.Current.MainPage.DisplayAlert("Editar Contato", "Erro ao editar Contato" + Erro, "Ok");
                }
            }

            await PushAsync(new ListaDeContatosView());
        }
    }
}
