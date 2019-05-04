using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Appf.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appf
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Anuncios : ContentPage
    {
        public ObservableCollection<Anuncio> Items { get; set; }

        /// <summary>
        /// Contrutor, jamais codigo pesado aqui!
        /// </summary>
        public Anuncios()
        { 
            InitializeComponent();

            Items = new ObservableCollection<Anuncio>();
            //Items.Add(new Anuncio() { Titulo = "Apartamento 3 quartos" });
            //Items.Add(new Anuncio() { Titulo = "Apartamento 2 garagens" });

            MyListView.ItemsSource = Items;

            //BindingContext = this;
            //InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Carregadados();

        }

        async Task Carregadados (string busca = "")
        {
            var url = "https://classidiario.odiario.com/api/busca/?busca=" + busca;

            var web = new HttpClient();

            var json = await web.GetStringAsync(url);

            var anuncios = JsonConvert.DeserializeObject<List<Anuncio>>(json);
            Items.Clear();

            foreach (var anuncio in anuncios)
            {
                Items.Add(anuncio);
            }

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null || !(e.Item is Anuncio))
                return;

            var item = (Anuncio)e.Item;
            //await DisplayAlert("Voce escolheu", item.Titulo, "OK");

            Navigation.PushAsync(new Detalhes(item));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void Handle_SearchButtonPressed(object sender, EventArgs e)
        {
            Carregadados(buscas.Text);
        }
    }
}
