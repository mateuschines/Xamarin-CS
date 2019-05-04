using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Appf
{
    public partial class Page4 : ContentPage
    {
        public Page4()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}
