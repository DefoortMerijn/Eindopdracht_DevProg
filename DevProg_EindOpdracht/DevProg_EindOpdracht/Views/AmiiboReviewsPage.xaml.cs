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
        public CharacterReview ReviewContent { get; set; }

        public AmiiboReviewsPage(CharacterReview review)
        {
            InitializeComponent();
            this.ReviewContent = review;
            ShowReviewsByID();
        }

        private async void ShowReviewsByID() {
            List<Review> reviews = await AmiiboRepository.GetAmiiboReviewsByIdAsync(ReviewContent.Id);
            collectionViewAmiiboReviews.ItemsSource = reviews;
            Debug.WriteLine(ReviewContent.Id);
/*            Review review = new Review() { AmiiboId = ReviewContent.Id, Name = "Merijn", ReviewText = "Middelmatig figuur", Rating = 2.5 };
            await AmiiboRepository.AddReviewAsync(review);*/



        }
    }
}