﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusContatos.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaDeContatosView : ContentPage
	{
		public ListaDeContatosView ()
		{
			InitializeComponent ();
		}

        private void IrParaCadastroContato(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroContatoViews());
        }
    }
}