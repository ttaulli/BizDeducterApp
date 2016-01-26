using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;
using BizDeducter.Model;


namespace BizDeducter.View
{
	public partial class TaxBracketPage : ContentPage
	{
		public TaxBracketPage ()
		{
			InitializeComponent ();

			BindingContext =  new TaxCalc  () {
				FederalTax="$0 (0% Bracket)", FilingStatus=0

			};

		}
	}
}












