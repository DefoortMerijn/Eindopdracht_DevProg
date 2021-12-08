using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevProg_EindOpdracht.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnedPage : ContentPage
    {
        public OwnedPage()
        {
            InitializeComponent();
        }


        private void TapGestureOverview_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());

            Debug.WriteLine("OverwiewPage");
        }

        private void TapGestureOwned_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OwnedPage());

            Debug.WriteLine("OwnedPage");
        }
    }
}