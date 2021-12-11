using DevProg_EindOpdracht.Models;
using DevProg_EindOpdracht.Repositories;
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
    public partial class AddReviewPage : ContentPage
    {
        public String AmiiboId { get; set; }

        public AddReviewPage(string Id)
        {
            this.AmiiboId = Id;
            InitializeComponent();
        }

        private async void CreateReview(String ReviewerName, String Review, Double AmiiboRating) {
            Review review = new Review() { AmiiboId = AmiiboId, Name = ReviewerName, ReviewText = Review, Rating = AmiiboRating };
            await AmiiboRepository.AddReviewAsync(review);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CreateReview(InputName.Text, InputReview.Text, double.Parse(InputRating.Text));
            Navigation.PopAsync();
            
        }
    }
}