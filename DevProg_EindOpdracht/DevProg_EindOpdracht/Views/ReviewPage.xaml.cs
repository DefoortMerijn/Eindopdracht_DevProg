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
/*    [XamlCompilation(XamlCompilationOptions.Compile)]*/
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage()
        {
            InitializeComponent();
            showReviewSubjects();
        }

        private async void showReviewSubjects() {
            List<Amiibo> amiibos = await AmiiboRepository.GetAmiibosAsync();

            List<Review> reviews = await AmiiboRepository.GetAmiiboReviewsAsync();
            List<CharacterReview> AmiiboReview = new List<CharacterReview>();

            List<string> amiiboseriesdistinct = amiibos.Select(x => x.Name).Distinct().ToList();
            amiiboseriesdistinct.Insert(0, "All");

            Picker picker = new Picker { Title = "Select a Name", TitleColor = Color.Black, WidthRequest = 100 };
            foreach (string item in amiiboseriesdistinct)
            {
                selectionAmiiboNames.Items.Add(item);
            }

            List<string> amiiboids = new List<string>();

            foreach (var item in amiibos)
            {

                foreach (var review in reviews)
                {
                    amiiboids.Add(review.AmiiboId);
                }

                if (amiiboids.Contains(item.Id))
                {
                    List<Review> revie = await AmiiboRepository.GetAmiiboReviewsByIdAsync(item.Id);

                    CharacterReview character = new CharacterReview();
                    character.Id = item.Id;
                    character.Name = item.Name;
                    character.Image = item.Image;
                    character.Rating = revie.Sum(rev => rev.Rating) / revie.Count;
                    AmiiboReview.Add(character);


                    revie.ForEach(rev => Debug.WriteLine($"{rev.Name}: {rev.Rating}"));
                    Debug.WriteLine("Total rating: " + (revie.Sum(rev => rev.Rating) / revie.Count));

                }
                else {
                    CharacterReview character = new CharacterReview();
                    character.Id = item.Id;
                    character.Name = item.Name;
                    character.Image = item.Image;
                    character.Rating = 0;
                    AmiiboReview.Add(character);


                }

            }
            collectionViewAmiiboReview.ItemsSource = AmiiboReview;




        }

        private async void selectionAmiiboNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                if (picker.Items[selectedIndex] == "All")
                {
                    showReviewSubjects();

                }
                else
                {
                    List<Amiibo> amiiboName = await AmiiboRepository.GetAmiibosByNameAsync(picker.Items[selectedIndex]);
                    List<Review> reviews = await AmiiboRepository.GetAmiiboReviewsAsync();
                    List<CharacterReview> AmiiboReview = new List<CharacterReview>();
                    List<string> amiiboids = new List<string>();

                    foreach (var item in amiiboName)
                    {

                        foreach (var review in reviews)
                        {
                            amiiboids.Add(review.AmiiboId);
                        }

                        if (amiiboids.Contains(item.Id))
                        {
                            List<Review> revie = await AmiiboRepository.GetAmiiboReviewsByIdAsync(item.Id);

                            CharacterReview character = new CharacterReview();
                            character.Id = item.Id;
                            character.Name = item.Name;
                            character.Image = item.Image;
                            Double Rating = revie.Sum(rev => rev.Rating) / revie.Count;
                            character.Rating = Math.Round(Rating, 1);
                            AmiiboReview.Add(character);


                        }
                        else
                        {
                            CharacterReview character = new CharacterReview();
                            character.Id = item.Id;
                            character.Name = item.Name;
                            character.Image = item.Image;
                            character.Rating = 0;
                            AmiiboReview.Add(character);


                        }

                    }
                    collectionViewAmiiboReview.ItemsSource = AmiiboReview;
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
        }

        private void collectionViewAmiiboReview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CharacterReview review = collectionViewAmiiboReview.SelectedItem as CharacterReview;
            Navigation.PushAsync(new AmiiboReviewsPage(review.Id));

        }

        private void TapGestureRefresh_Tapped(object sender, EventArgs e)
        {
            showReviewSubjects();
        }
    }
}