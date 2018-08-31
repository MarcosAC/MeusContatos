﻿using MeusContatos.BD.Repositorio;
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
        private readonly IPaginaServico _paginaServico;

        public Command IrParaAdicionarContatoCommand { get; }
        public Command SelecionarContatoCommand { get; }
        
        public ObservableCollection<Contato> listaDeContatos { get; }
        
        public ListaDeContatosViewModel()
        {
            _contatoRepositorio = new ContatoRepositorio();

            _paginaServico = new PaginaServico();

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
                ListaDeContatos(_filtro);
            }
        }

        private List<Contato> ListaDeContatos(string filtro = null)
        {
            if (filtro != null)
            {
                var contatos = _contatoRepositorio.PesquisarContato(filtro);

                listaDeContatos.Clear();

                foreach (var contato in contatos)
                {
                    listaDeContatos.Add(contato);
                }
            }

            return _contatoRepositorio.ObterTodosContatos();
        }

        private async void ExecuteIrParaAdicionarContatoCommand()
        {
            await _paginaServico.PushModalAsync(new NavigationPage(new AdicionarContatoView()));
        }

        private async Task ExecuteSelecionarContatoCommand(Contato contaSelecionado)
        {
            if (contaSelecionado == null)
                return;

            await _paginaServico.PushModalAsync(new NavigationPage(new EditarContatoView(contaSelecionado)));
        }
    }
}