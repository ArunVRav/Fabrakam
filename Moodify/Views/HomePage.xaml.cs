using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Moodify.DataModels;
using Newtonsoft.Json;

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
        async void logClicked(object sender, EventArgs e)
        {
            var experiment = await AzureManager.AzureManagerInstanceLogins.GetLogins();
            bool isWorking = false;
            foreach (logins login in experiment)
            {
                if(email.Text == login.Email)
                {
                    if(Pass.Text != login.Password)
                    {
                        ErrorMsg.Text = "Sorry, your password doesn't match that of the email inputted";
                        break;
                    }else
                    {
                        isWorking = true;
                        break;
                    }
                }
            }
            if (isWorking == true)
            {
                App.RootPage.Detail = new NavigationPage(new YourOrders());
                App.RootPage.Master.IsVisible = true;
            }
            else
            {
                ErrorMsg.Text = "Sorry, that email has not been registered yet, go ahead and register!";
            }
        }
    }
}
