using MeusContatos.BD.Repositorio;
using MeusContatos.Models;
using MeusContatos.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeusContatos.ViewModels
{
    public class ListaDeContatosViewModel : BaseViewModel
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private ContatoViewModel _contatoSelecionado;
        
        public Command IrParaCadastroContatoCommand { get; }
        public Command SelecionarContatoCommand { get; }
        
        public List<Contato> listaDeContatos { get; }

        public ListaDeContatosViewModel()
        {
            _contatoRepositorio = new ContatoRepositorio();
            
            listaDeContatos = ListaDeContatos();

            IrParaCadastroContatoCommand = new Command(ExecuteIrParaCadastroContatoCommand);
            SelecionarContatoCommand = new Command<Contato>(async c => await ExecuteSelecionarContatoCommand(c));
        }

        private Task ExecuteSelecionarContatoCommand(object idContato)
        {
            throw new NotImplementedException();
        }

        public ContatoViewModel ContatoSelecionado
        {
            get { return _contatoSelecionado; }
            set
            {
                SetProperty(ref _contatoSelecionado, value);
            }
        }

        private List<Contato> ListaDeContatos()
        {
            return _contatoRepositorio.ObterTodosContatos();
        }

        private async void ExecuteIrParaCadastroContatoCommand()
        {
            await PushAsync(new CadastroContatoView());
        }

        private async Task ExecuteSelecionarContatoCommand(Contato contaSelecionado)
        {
            if (contaSelecionado == null)
                return;

            var dadosContato = _contatoRepositorio.ObterContato(contaSelecionado.IdContato);

            ContatoSelecionado = null;

            await PushAsync(new EditarContatoView(dadosContato));
        }
    }
}
