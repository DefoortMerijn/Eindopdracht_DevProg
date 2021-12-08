using DevProg_EindOpdracht.Models;
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
            lblType.Text = AmiiboContent.Type;
            lblId.Text = AmiiboContent.Id;
            if (AmiiboContent.Release["au"] != null)
            {
                lblAU.Text = AmiiboContent.Release["au"];
            }
            else
            {
                lblAU.Text = "/";
            }
            if (AmiiboContent.Release["eu"] != null)
            {
                lblEU.Text = AmiiboContent.Release["eu"];
            }
            else
            {
                lblEU.Text = "/";
            }
            if (AmiiboContent.Release["jp"] != null)
            {
                lblJP.Text = AmiiboContent.Release["jp"];
            }
            else
            {
                lblJP.Text = "/";
            }
            if (AmiiboContent.Release["na"] != null)
            {
                lblNA.Text = AmiiboContent.Release["na"];
            }
            else
            {
                lblNA.Text = "/";
            }
            lblName.Text = AmiiboContent.Name;
            lblAmiiboSeries.Text = AmiiboContent.AmiiboSeries;
            lblGameSeries.Text = AmiiboContent.GameSeries;
            ImgAmiibo.Source = AmiiboContent.Image;
        
        }
    }
}