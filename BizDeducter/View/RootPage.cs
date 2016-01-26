using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using BizDeducter.Controls;
using BizDeducter.Model;
using BizDeducter.ViewModel;

namespace BizDeducter.View
{
    public class RootPage : MasterDetailPage
    {
        Dictionary<PageId, NavigationPage> Pages { get; } = new Dictionary<PageId, NavigationPage>();
        public RootPage()
        {
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel
                {
                    Title = "BizDeductor"
                };
            //setup home page
            NavigateAsync(PageId.Home);
        }



        public async Task NavigateAsync(PageId id)
        {
            Page newPage;
            if (!Pages.ContainsKey(id))
            {

                switch (id)
                {


                    case PageId.Home:
                        Pages.Add(id, new BizDeducterNavigationPage(new HomePage()));
                        break;
					case PageId.Feedback:
						Pages.Add(id, new BizDeducterNavigationPage(new FeedbackPage()));
						break;
					case PageId.TaxCalendar:
						Pages.Add(id, new BizDeducterNavigationPage(new TaxCalendarPage()));
						break;
					case PageId.TaxBracket:
						Pages.Add(id, new BizDeducterNavigationPage(new TaxBracketPage()));
						break;

                }
            }

            newPage = Pages[id];
            if(newPage == null)
                return;

            //pop to root for Windows Phone
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            if(Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }
}

