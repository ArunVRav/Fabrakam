using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moodify
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
		}
        void signClicked(object sender, EventArgs e)
        {
            App.RootPage.Detail = new NavigationPage(new SignUp());
        }
        void logClicked(object sender, EventArgs e)
        {
            App.RootPage.Detail = new NavigationPage(new YourOrders());
            App.RootPage.Master.IsVisible = true;
        }
    }
}
