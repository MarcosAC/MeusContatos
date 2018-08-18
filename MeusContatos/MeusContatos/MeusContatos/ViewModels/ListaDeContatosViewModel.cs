using MeusContatos.BD.Repositorio;
using MeusContatos.Models;
using MeusContatos.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MeusContatos.ViewModels
{
    public class ListaDeContatosViewModel : ContatoViewModel
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public List<Contato> listaDeContatos { get; }

        public Command IrParaCadastroContatoCommand { get; }

        public ListaDeContatosViewModel()
        {
            _contatoRepositorio = new ContatoRepositorio();

            listaDeContatos = ListaDeContatos();

            IrParaCadastroContatoCommand = new Command(ExecuteIrParaCadastroContatoCommand);
        }

        private List<Contato> ListaDeContatos()
        {
            return _contatoRepositorio.ObterTodosContatos();
        }

        private async void ExecuteIrParaCadastroContatoCommand()
        {
            await PushAsync(new CadastroContatoView());
        }
    }
}
