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
            List<string> amiiboseries = new List<string>();

/*
            foreach (var item in amiibos.Distinct()){
                Debug.WriteLine(item.Name);
            }*/

            foreach (var item in amiibos) {
/*                Debug.WriteLine(item.AmiiboSeries);*/

                amiiboseries.Add(item.AmiiboSeries);
/*              
                var Amiiboserie = item.AmiiboSeries;
                if(amiiboseries.Contains(Amiiboserie)){ }*/
            
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
    }
}
