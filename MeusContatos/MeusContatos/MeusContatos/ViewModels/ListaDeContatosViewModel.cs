using MeusContatos.BD.Repositorio;
using MeusContatos.Models;
using MeusContatos.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeusContatos.ViewModels
{
    public class ListaDeContatosViewModel : BaseViewModel
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        
        public Command IrParaAdicionarContatoCommand { get; }
        public Command SelecionarContatoCommand { get; }
        
        public ObservableCollection<Contato> listaDeContatos { get; }
        
        public ListaDeContatosViewModel()
        {
            _contatoRepositorio = new ContatoRepositorio();

            listaDeContatos = new ObservableCollection<Contato>(ListaDeContatos());

            IrParaAdicionarContatoCommand = new Command(ExecuteIrParaAdicionarContatoCommand);
            SelecionarContatoCommand = new Command<Contato>(async c => await ExecuteSelecionarContatoCommand(c));
        }

        private string _filtro;
        public string Filtro
        {
            get { return _filtro; }
            set
            {                
                SetProperty(ref _filtro, value);
                PesquisarContatos(_filtro);
            }
        }

        private List<Contato> ListaDeContatos()
        {   
            return _contatoRepositorio.ObterTodosContatos();
        }

        public void PesquisarContatos(string filtro)
        {
            var contatos = _contatoRepositorio.PesquisarContato(filtro);

            listaDeContatos.Clear();

            foreach (var contato in contatos)
            {
                listaDeContatos.Add(contato);
            }                       
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