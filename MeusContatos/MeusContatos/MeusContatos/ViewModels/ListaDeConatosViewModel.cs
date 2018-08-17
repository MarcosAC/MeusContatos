using MeusContatos.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MeusContatos.ViewModels
{
    public class ListaDeConatosViewModel : BaseViewModel
    {
        public Command IrParaCadastroContatoCommand { get; }

        public ListaDeConatosViewModel()
        {
            IrParaCadastroContatoCommand = new Command(ExecuteIrParaCadastroContatoCommand);
        }

        private async void ExecuteIrParaCadastroContatoCommand()
        {
            await PushAsync(new CadastroContatoViews());
        }
    }
}
