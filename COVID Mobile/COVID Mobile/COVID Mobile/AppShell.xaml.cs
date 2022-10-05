using COVID_Mobile.ViewModels;
using COVID_Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace COVID_Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
