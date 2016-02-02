using System;
using Xamarin.Forms;

namespace BizDeducter.Controls
{
    public class BizDeducterNavigationPage : NavigationPage
    {
        public BizDeducterNavigationPage(Page root) : base(root)
        {
            Init();
        }

        public BizDeducterNavigationPage()
        {
            Init();
        }

        void Init()
        {

			BarBackgroundColor = Color.Green;
            BarTextColor = Color.White;

        }
    }
}

