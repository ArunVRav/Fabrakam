using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moodify
{
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }
        void signClicked(object sender, EventArgs e)
        {
            App.RootPage.Detail = new NavigationPage(new YourOrders());
            App.RootPage.Master.IsVisible = true;
        }
    }
}
