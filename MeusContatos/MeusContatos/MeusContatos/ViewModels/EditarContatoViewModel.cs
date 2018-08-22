using MeusContatos.BD.Repositorio;
using MeusContatos.Models;

namespace MeusContatos.ViewModels
{
    public class EditarContatoViewModel : BaseViewModel
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public Contato _dadosContato;

        public EditarContatoViewModel(Contato contatoSelecionado)
        {
            _contatoRepositorio = new ContatoRepositorio();

            _dadosContato = contatoSelecionado;
        }

        private string _NomeContato;
        public string NomeContato
        {
            get { return _dadosContato.NomeContato; }
            set
            {
                SetProperty(ref _NomeContato, value);
            }
        }

        private string _Celular;
        public string Celular
        {
            get { return _dadosContato.Celular; }
            set
            {
                SetProperty(ref _Celular, value);
            }
        }

        private string _TelefoneFixo;
        public string TelefoneFixo
        {
            get { return _dadosContato.TelefoneFixo; }
            set
            {
                SetProperty(ref _TelefoneFixo, value);
            }
        }
    }
}
