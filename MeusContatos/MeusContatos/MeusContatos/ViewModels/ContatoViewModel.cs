using System;
using System.Collections.Generic;
using System.Text;

namespace MeusContatos.ViewModels
{
    public class ContatoViewModel : BaseViewModel
    {
        public ContatoViewModel()
        {

        }

        private string _NomeContato;
        public string NomeContato
        {
            get { return _NomeContato; }
            set
            {
                _NomeContato = value;
                OnPropertyChanged();
            }
        }

        private string _Celular;
        public string Celular
        {
            get { return _Celular; }
            set
            {
                _Celular = value;
                OnPropertyChanged();
            }
        }

        private string _TelefoneFixo;
        public string TelefoneFixo
        {
            get { return _TelefoneFixo; }
            set
            {
                _TelefoneFixo = value;
                OnPropertyChanged();
            }
        }
    }
}
