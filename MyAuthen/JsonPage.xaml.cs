using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyAuthen.Helpers;
using MyAuthen.Models;
using MyAuthen.Services;
using Xamarin.Forms;

namespace MyAuthen
{
    public partial class JsonPage : ContentPage
    {
        public JsonPage()
        {
            InitializeComponent();


            FeedData();
        }

        private void FeedData()
        {
            Task.Run(async () => {
                // background thread
                var username = Setting.UserName;
                var password = Setting.Password;
                var user = new User(username, password);

                var result = await NetworkService.GetData(user);


                Device.BeginInvokeOnMainThread(() => {
                    // main thread
                    if (result != null)
                    {
                        JSONListView.ItemsSource = result.youtubes;
                    }
                    else
                    {
                        // todo
                    }

                    Loading.IsRunning = false;
                });
            });
        }


        private void OpenYoutube(Object sender, ItemTappedEventArgs events)
        {
            // de-select
            JSONListView.SelectedItem = false;

            var item = events.Item as Youtube;

            // Dependency Service
            DependencyService.Get<IYoutubeService>().PlayYoutube(item.id);

        }
    }
}
