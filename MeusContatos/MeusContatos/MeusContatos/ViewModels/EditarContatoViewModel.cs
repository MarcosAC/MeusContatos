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
        private readonly IPaginaServico _paginaServico;

        public Contato _dadosContato;

        public Command EditarContatoCommand { get; }
        public Command DeletarContatoCommand { get; }

        public EditarContatoViewModel(Contato contatoSelecionado)
        {
            _contatoRepositorio = new ContatoRepositorio();

            _paginaServico = new PaginaServico();

            _dadosContato = contatoSelecionado;

            EditarContatoCommand = new Command(async () => await ExecuteEditarContatoCommand());
            DeletarContatoCommand = new Command(async () => await ExecuteDeletarContatoCommand());
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
            bool contatoAceito = await _paginaServico.DisplayAlert("Editar Contato", "Deseja editar Contato?", "Sim", "Não");

            if (contatoAceito)
            {
                try
                {
                    _contatoRepositorio.EditarContato(_dadosContato);
                    await _paginaServico.DisplayAlert("", "Contato editado com sucesso.", "Ok");
                }
                catch (Exception Erro)
                {
                    await _paginaServico.DisplayAlert("Editar Contato", "Erro ao editar Contato" + Erro, "Ok");
                }
            }

            await PushAsync(new ListaDeContatosView());
        }

        private async Task ExecuteDeletarContatoCommand()
        {
            bool contatoAceito = await _paginaServico.DisplayAlert("Excluir Contato", "Deseja excluir Contato?", "Sim", "Não");

            if (contatoAceito)
            {
                try
                {
                    _contatoRepositorio.DeletarContato(_dadosContato.IdContato);
                    await _paginaServico.DisplayAlert("", "Contato excluido com sucesso.", "Ok");
                }
                catch (Exception Erro)
                {
                    await _paginaServico.DisplayAlert("Excluir Contato", "Erro ao excluir Contato" + Erro, "Ok");
                }
            }

            await PushAsync(new ListaDeContatosView());            
        }
    }
}
