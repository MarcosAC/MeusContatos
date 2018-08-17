using MeusContatos.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MeusContatos.ViewModels
{
    public class ListaDeContatosViewModel : BaseViewModel
    {
        public Command IrParaCadastroContatoCommand { get; }

        public ListaDeContatosViewModel()
        {
            IrParaCadastroContatoCommand = new Command(ExecuteIrParaCadastroContatoCommand);
        }

        private async void ExecuteIrParaCadastroContatoCommand()
        {
            await PushAsync(new CadastroContatoView());
        }
    }
}
