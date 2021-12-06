using DevProg_EindOpdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevProg_EindOpdracht.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public Amiibo AmiiboContent { get; set; }
        public DetailPage(Amiibo amiibo)
        {
            InitializeComponent();
            this.AmiiboContent = amiibo;
            ShowDetails();
        }

        private void ShowDetails() {

            lblName.Text = AmiiboContent.Name;
            lblAmiiboSeries.Text = AmiiboContent.AmiiboSeries;
            lblGameSeries.Text = AmiiboContent.GameSeries;
            ImgAmiibo.Source = AmiiboContent.Image;
        
        }
    }
}