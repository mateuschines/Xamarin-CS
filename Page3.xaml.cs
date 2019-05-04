using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Appf
{
    public partial class Page3 : ContentPage
    {

        //public Command Sair { get; set; }
        public Page3()
        {
            //BindingContext = this;
            InitializeComponent();
            //Sair = new Command(Saiir);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {//funcao para voltar a tela inicial
            //Navigation.PushAsync(new Page4());

            Navigation.PushAsync(new Page4());

        }

        /*void Saiir()
        {
            Application.Current.MainPage = new MainPage();
        }*/
    }
}
