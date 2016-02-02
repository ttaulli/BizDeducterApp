using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using BizDeducter.Helpers;
using BizDeducter.Model;

namespace BizDeducter.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        protected Page page;

        public BaseViewModel(Page page = null)
        {
            this.page = page;
        }

        public Settings Settings
        {
            get { return Settings.Current; }
        }

        string title = string.Empty;

        /// <summary>
        /// Gets or sets the "Title" property
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string subTitle = string.Empty;

        /// <summary>
        /// Gets or sets the "Subtitle" property
        /// </summary>
        public string Subtitle
        {
            get { return subTitle; }
            set { SetProperty(ref subTitle, value); }
        }



        string icon = "slideout.png";

        /// <summary>
        /// Gets or sets the "Icon" of the viewmodel
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        bool isBusy;

        /// <summary>
        /// Gets or sets if the view is busy.
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        bool canLoadMore = true;

        /// <summary>
        /// Gets or sets if we can load more.
        /// </summary>
        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { SetProperty(ref canLoadMore, value); }
        }
    }
}

