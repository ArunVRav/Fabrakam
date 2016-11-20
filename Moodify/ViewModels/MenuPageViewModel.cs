using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Moodify
{
	public class MenuPageViewModel
	{
		public ICommand GoHomeCommand { get; set; }
		public ICommand GoOrderCommand { get; set; }
        public ICommand GoNewCommand { get; set; }
        public ICommand GoSignCommand { get; set; }

		public MenuPageViewModel()
		{
			GoHomeCommand = new Command(GoHome);
			GoOrderCommand = new Command(GoOrder);
            GoNewCommand = new Command(GoNew);
            GoSignCommand = new Command(GoSign);
		}

		void GoHome(object obj)
		{
            App.RootPage.Detail = new NavigationPage(new HomePage());
			App.MenuIsPresented = false;
		}

		void GoOrder(object obj)
		{
            App.RootPage.Detail = new NavigationPage(new YourOrders());
            App.MenuIsPresented = false;
		}
        void GoNew(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new NewOrder());
            App.MenuIsPresented = false;
        }
        void GoSign(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new SignUp());
            App.MenuIsPresented = true;
            App.RootPage.Master.IsVisible = false;
        }
    }
}
