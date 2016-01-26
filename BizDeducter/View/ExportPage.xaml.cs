using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;

namespace BizDeducter.View
{
    public partial class ExportPage : ContentPage
    {
        public ExportPage()
        {
            InitializeComponent();
            BindingContext = new ExportViewModel(this);
        }
    }
}

