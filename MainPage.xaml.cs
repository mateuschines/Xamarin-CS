using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Appf
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        public String Email { get; set; }
        public String Senha { get; set; }
        public Command EntrarCommand { get; set; }

        public MainPage()
        {
            BindingContext = this;// qual classe representa meu contexto para biding

            //inicializacaol de propriedades
            Email = "mateus@live.com";
            Senha = "123";

            EntrarCommand = new Command(Entrar);
            InitializeComponent();
        }



        void Handle_Clicked(object sender, System.EventArgs e)
        {
        //    DisplayAlert("Voçe digitou", Email + ":" +Senha, "OK");
        //    //Navigation.PushModalAsync(new Page3());
        }

        async void Entrar()
        {
            //await Task.Delay(10000);

            if (Email == null || Senha == null)
            {
                await DisplayAlert( "Mensagem", "digite um email e uma senha", "Volta");

            }
            else if (Email != "mateus@live.com" || Senha != "123")
            {
                await DisplayAlert("Mensagem", "Dados incorretos", "OK");
            } else
            {

                var texto = Email + "\r\n" + Senha;

                //await DisplayAlert("Voçe digitou", texto, "OK");

                //await Navigation.PushAsync(new Page3());

                Application.Current.MainPage = new NavigationPage(new Anuncios());
            }

        }
    }
}
