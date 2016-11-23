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
            bool idDetected = false;
            int indenter = -1;
            foreach (logins login in experiment)
            {
                indenter++;
                if (email.Text == login.Email)
                {
                    if (Pass.Text != login.Password)
                    {
                        ErrorMsg.Text = "Sorry, your password doesn't match that of the email inputted";
                        idDetected = true;
                        break;
                    }
                    else
                    {
                        logins.CurrentName = login.Email;
                        logins.indexer = indenter;
                        App.RootPage.Detail = new NavigationPage(new YourOrders());
                        App.RootPage.Master.IsVisible = true;
                        break;
                    }
                }
            }
            if (idDetected != true)
            {
                ErrorMsg.Text = "Sorry, that email has not been registered yet, go ahead and register!";
            }
        }
    }
}

