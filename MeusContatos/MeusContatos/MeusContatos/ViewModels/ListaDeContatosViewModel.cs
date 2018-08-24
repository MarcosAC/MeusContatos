using MeusContatos.BD.Repositorio;
using MeusContatos.Models;
using MeusContatos.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeusContatos.ViewModels
{
    public class ListaDeContatosViewModel : BaseViewModel
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        
        public Command IrParaAdicionarContatoCommand { get; }
        public Command SelecionarContatoCommand { get; }
        
        public List<Contato> listaDeContatos { get; }

        public ListaDeContatosViewModel()
        {
            _contatoRepositorio = new ContatoRepositorio();
            
            listaDeContatos = ListaDeContatos();

            IrParaAdicionarContatoCommand = new Command(ExecuteIrParaAdicionarContatoCommand);
            SelecionarContatoCommand = new Command<Contato>(async c => await ExecuteSelecionarContatoCommand(c));
        }

        private Contato _ContatoSelecionado;
        public Contato ContatoSelecionado
        {
            get { return _ContatoSelecionado; }
            set
            {
                SetProperty(ref _ContatoSelecionado, value);
            }
        }

        private List<Contato> ListaDeContatos()
        {
            return _contatoRepositorio.ObterTodosContatos();
        }

        private async void ExecuteIrParaAdicionarContatoCommand()
        {
            await PushAsync(new AdicionarContatoView());
        }

        private async Task ExecuteSelecionarContatoCommand(Contato contaSelecionado)
        {
            if (contaSelecionado == null)
                return;

            await PushAsync(new EditarContatoView(contaSelecionado));
        }
    }
}
