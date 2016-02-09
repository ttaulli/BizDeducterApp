using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.Model;
using BizDeducter.ViewModel;

namespace BizDeducter.View
{
    public partial class MenuPage : ContentPage
    {
        RootPage root;
        List<NavigationItem> menuItems;
        public MenuPage(RootPage root)
        {
            this.root = root;
            InitializeComponent();
            BindingContext = new BaseViewModel
            {
                    Title = "BizDeducter"
            };
            
            ListViewMenu.ItemsSource = menuItems = new List<NavigationItem>
                {
                    new NavigationItem { Name = "Home", Id = PageId.Home },
					new NavigationItem { Name = "Tax Calendar", Id = PageId.TaxCalendar },
					new NavigationItem { Name = "Tax Bracket Calc", Id = PageId.TaxBracket }
					
                };

            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) => 
                {
                    if(ListViewMenu.SelectedItem == null)
                        return;

                    await this.root.NavigateAsync(((NavigationItem)e.SelectedItem).Id);
                };
        }
    }
}

