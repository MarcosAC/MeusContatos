using MeusContatos.BD.Repositorio;
using MeusContatos.Models;
using MeusContatos.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeusContatos.ViewModels
{
    public class AdicionarContatoViewModel : BaseViewModel
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly IPaginaServico _paginaServico;

        public Command AdicionarContatoCommand { get; }

        public AdicionarContatoViewModel()
        {
            _contatoRepositorio = new ContatoRepositorio();

            _paginaServico = new PaginaServico();
            
            AdicionarContatoCommand = new Command(async () => await ExecuteAdicionarContatoCommand());
        }

        private string _NomeContato;
        public string NomeContato
        {
            get { return _NomeContato; }
            set
            {
                SetProperty(ref _NomeContato, value);                
            }
        }

        private string _Celular;
        public string Celular
        {
            get { return _Celular; }
            set
            {
                SetProperty(ref _Celular, value);                
            }
        }

        private string _TelefoneFixo;
        public string TelefoneFixo
        {
            get { return _TelefoneFixo; }
            set
            {
                SetProperty(ref _TelefoneFixo, value);                
            }
        }

        List<Contato> _ListaDeContatos;
        public List<Contato> ListaDeContatos
        {
            get { return _ListaDeContatos; }
            set
            {
                SetProperty(ref _ListaDeContatos, value);
            }
        }

        private async Task ExecuteAdicionarContatoCommand()
        {
            try
            {
                var contato = new Contato
                {
                    NomeContato = NomeContato,
                    Celular = Celular,
                    TelefoneFixo = TelefoneFixo
                };

                bool contatoAceito = await _paginaServico.DisplayAlert("Adicionar Contato", "Deseja adicionar Contato?", "Sim", "Não");

                if (contatoAceito)
                {
                    try
                    {
                        _contatoRepositorio.AdicionarContato(contato);
                        await _paginaServico.DisplayAlert("", "Contato adicionado com sucesso.", "Ok");                        
                    }
                    catch (Exception Erro)
                    {
                        await _paginaServico.DisplayAlert("Adicionar Contato", "Erro ao adicionar Contato" + Erro, "Ok");
                    }

                    await PushAsync(new ListaDeContatosView());
                }
            }
            catch (Exception Erro)
            {
                await _paginaServico.DisplayAlert("Adicionar Contato", "Erro ao adicionar Contato" + Erro, "Ok");
                await PushAsync(new ListaDeContatosView());
            }
        }
    }
}
