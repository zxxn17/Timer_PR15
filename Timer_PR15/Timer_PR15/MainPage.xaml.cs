using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Timer_PR15.Models;

namespace Timer_PR15
{
    public partial class MainPage : ContentPage
    {
        bool alive = false;
        private DateTime StartTime;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new Results();

            timerButton.Clicked += TimerButton_Clicked;

            StartTime = DateTime.Now;
            //Device.StartTimer(TimeSpan.FromSeconds(0), OnTimerTick);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetResultsAsync();
        }

        private bool OnTimerTick()
        {
            TimerText.Text = (DateTime.Now - StartTime).ToString(@"hh':'mm':'ss'.'f");
            return alive;
        }

        private async void TimerButton_Clicked(object sender, EventArgs e)
        {
            if (alive == true)
            {
                alive = false;
                timerButton.Text = "Начать?";

                var result = (Results)BindingContext;
                result.Result = TimerText.Text;
                if ((!string.IsNullOrWhiteSpace(result.Text)) && (!string.IsNullOrWhiteSpace(result.Result)))
                {
                    await App.Database.SaveResultsAsync(result);
                }

                collectionView.ItemsSource = null;
                collectionView.ItemsSource = await App.Database.GetResultsAsync();
                BindingContext = new Results();
            }
            else
            {
                alive = true;
                StartTime = DateTime.Now;
                Device.StartTimer(TimeSpan.FromSeconds(0), OnTimerTick);

                timerButton.Text = "Стоп! Снято!";
            }
        }
    }
}
