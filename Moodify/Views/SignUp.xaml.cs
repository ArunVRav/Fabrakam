using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Moodify.DataModels;

namespace Moodify
{
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }
        public async void signClicked(object sender, EventArgs e)
        {
            logins newLog = new DataModels.logins()
            {
                Email = email.Text,
                Password = pass.Text
            };
            await AzureManager.AzureManagerInstanceLogins.AddLogin(newLog);
            App.RootPage.Detail = new NavigationPage(new YourOrders());
            App.RootPage.Master.IsVisible = true;
        }
    }
}
