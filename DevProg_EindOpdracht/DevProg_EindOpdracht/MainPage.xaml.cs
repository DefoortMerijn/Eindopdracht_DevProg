using DevProg_EindOpdracht.Models;
using DevProg_EindOpdracht.Repositories;
using DevProg_EindOpdracht.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevProg_EindOpdracht
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TestRepo();
        }

        private async void TestRepo()
        {
            List<Amiibo> amiibos = await AmiiboRepository.GetAmiibosAsync();

/*            foreach (var item in amiibos) {
                Debug.WriteLine(item.Name);
            }*/

            List<string> amiiboseries = new List<string>();

            amiiboseries.Add("All");

            foreach (var item in amiibos) {
                amiiboseries.Add(item.AmiiboSeries);
            }
            List<string> amiiboseriesdistinct = amiiboseries.Distinct().ToList();


            Picker picker = new Picker { Title = "Select a AmiiboSeries", TitleColor = Color.Black, WidthRequest= 100 };
            foreach (string item in amiiboseriesdistinct){
                selectionAmiiboSeries.Items.Add(item);
                    }
            
            collectionViewListHorizontal.ItemsSource = amiibos;

        }

        private void collectionViewListHorizontal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Amiibo amiibo = collectionViewListHorizontal.SelectedItem as Amiibo;

            if (amiibo != null) {
                Navigation.PushAsync(new DetailPage(amiibo));
            
            }
        
        }

        private async void selectionAmiiboSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            
            if (selectedIndex != -1)
            {
                if (picker.Items[selectedIndex] == "All") {
                    List<Amiibo> amiibo = await AmiiboRepository.GetAmiibosAsync();
                    collectionViewListHorizontal.ItemsSource = amiibo;

                }
                else
                {
                    List<Amiibo> amiiboserie = await AmiiboRepository.GetAmiibosBySerieAsync(picker.Items[selectedIndex]);
                    collectionViewListHorizontal.ItemsSource = amiiboserie;
                }
                Debug.WriteLine(picker.Items[selectedIndex]);
            }
        }

        private void TapGestureOverview_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void TapGestureOwned_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReviewPage());
            Debug.WriteLine("OwnedPage");
        }
    }
}
