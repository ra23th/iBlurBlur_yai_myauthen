using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyAuthen
{
    public partial class ListAccountPage : ContentPage
    {
        public ListAccountPage()
        {
            InitializeComponent();

            // Dummy
            CustomListView.ItemsSource = new String[10];
        }
    }
}
