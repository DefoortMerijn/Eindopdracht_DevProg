using DevProg_EindOpdracht.Models;
using DevProg_EindOpdracht.Repositories;
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
    public partial class AmiiboReviewsPage : ContentPage
    {
        public String AmiiboId{ get; set; }

        public AmiiboReviewsPage(String Id)
        {
            InitializeComponent();
            this.AmiiboId = Id;
            ShowReviewsByID();
        }

        private async void ShowReviewsByID() {
            List<Review> reviews = await AmiiboRepository.GetAmiiboReviewsByIdAsync(AmiiboId);
            collectionViewAmiiboReviews.ItemsSource = reviews;
            Debug.WriteLine(AmiiboId);




        }

        private void TapGestureReview_Tapped(object sender, EventArgs e)
        {
            Debug.WriteLine("Going to update this review");
            Navigation.PushAsync(new UpdateReviewPage());

        }

        private void TapGestureAdd_Tapped(object sender, EventArgs e)
        {
            Debug.WriteLine("Going to Add a review");
            Navigation.PushAsync(new AddReviewPage(AmiiboId));


        }

        private void TapGestureRefresh_Tapped(object sender, EventArgs e)
        {
            ShowReviewsByID();
        }
    }
}