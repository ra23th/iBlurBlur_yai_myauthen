using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAuthen.Helpers;
using MyAuthen.Models;
using Xamarin.Forms;

namespace MyAuthen
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private DatabaseAdapter DatabaseAdapter;

        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            UsernameEntry.Text = Setting.UserName;
            PasswordEntry.Text = Setting.Password;

            DatabaseAdapter = new DatabaseAdapter(App.DatabasePath);
        }

        public void Login_clicked(object sender, EventArgs args)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            var result = DatabaseAdapter.GetUser(username);
            if(result == null)
            {
               var count = DatabaseAdapter.AddUser(new User(username, password));
               DisplayAlert("title", $"insert: {count}", "close");
            }
            else if(result.Password == password)
            {
                Setting.UserName = username;
                Setting.Password = password;

                DisplayAlert("title", $"login: {username}, {password}", "close");
            }
            else
            {
                var count = DatabaseAdapter.EditUser(new User(username, password));
                DisplayAlert("title", $"edit: {count}", "close");
            }
        }

        public void Delete_clicked(object sender, EventArgs args)
        {
            DisplayAlert("title", "delete", "close");
        }

        public void List_clicked(object sender, EventArgs args)
        {
            DisplayAlert("title", "list", "close");
        }

    }
}
