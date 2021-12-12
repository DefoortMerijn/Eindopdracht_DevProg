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
    public partial class UpdateReviewPage : ContentPage
    {
        public Review reviewcontent { get; set; }


        public UpdateReviewPage(Review review)
        {
            InitializeComponent();
            this.reviewcontent = review;
            showReviewData();
        }

        private void showReviewData() {
            InputName.Text = reviewcontent.Name;
            InputRating.Text = reviewcontent.Rating.ToString();
            InputReview.Text = reviewcontent.ReviewText;
        
        }

        private async void UpdateReview(String ReviewerName, String Review, Double AmiiboRating, String ReviewId)
        {
            Review review = new Review() { ReviewId = ReviewId, Name = ReviewerName, ReviewText = Review, Rating = AmiiboRating };
            await AmiiboRepository.UpdatReviewAsync(review);
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            UpdateReview(InputName.Text, InputReview.Text, double.Parse(InputRating.Text), reviewcontent.ReviewId);
            Navigation.PopAsync();
        }
    }
}