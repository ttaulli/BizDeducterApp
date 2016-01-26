using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;



namespace BizDeducter.Model

{

	 

	public class SampleCommand: ICommand {

		private Action _toExecute;


		public SampleCommand( Action toExecute) {
			_toExecute = toExecute;

		}

		public bool CanExecute( object parameter) {
			return true;
		}

		public void Execute( object parameter) {
			_toExecute();
		}

		public event EventHandler CanExecuteChanged;

	}

	public class TaxCalc : INotifyPropertyChanged
	{





		private string _federalTax;

		public string FederalTax { 
			get { return _federalTax; }
			set {
				if (_federalTax != value) {
					_federalTax = value;
					OnPropertyChanged ("FederalTax");

				}        
			}
		}

		private double _annualIncome;

		public double AnnualIncome { 
			get { return _annualIncome; }
			set {
				if (_annualIncome != value) {
					_annualIncome = value;
					OnPropertyChanged ("AnnualIncome");

				}        
			}
		}

		private int _filingStatus;

		public int FilingStatus { 
			get { return _filingStatus; }
			set {
				if (_filingStatus != value) {
					_filingStatus = value;
					OnPropertyChanged ("FilingStatus");

				}        
			}
		}




		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged (string propertyName)
		{
			var changed = PropertyChanged;
			if (changed != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
			}
		}


		public string GetTax() {

			double finalTax = 0;
			double _taxBracket = 0;

			if (_filingStatus == 0) {

				if (_annualIncome <= 9225) {
					finalTax = _annualIncome * 0.10;    
					_taxBracket = 10;
				}

				if ((_annualIncome > 9225) && (_annualIncome <= 37450)) {
					finalTax = (_annualIncome - 9225) * 0.15 + 922.50;
					_taxBracket = 15;    
				}

				if ((_annualIncome > 37450) && (_annualIncome <= 90750)) {
					finalTax = (_annualIncome - 37450) * 0.25 + 5156.25;
					_taxBracket = 25;    
				}

				if ((_annualIncome > 90750) && (_annualIncome <= 189300)) {
					finalTax = (_annualIncome - 90750) * 0.28 + 18481.25;
					_taxBracket = 28;    
				}

				if ((_annualIncome > 189300) && (_annualIncome <= 411500)) {
					finalTax = (_annualIncome - 189300) * 0.33 + 46075.25;
					_taxBracket = 33;    
				}

				if ((_annualIncome > 411500) && (_annualIncome <= 413200)) {
					finalTax = (_annualIncome - 411500) * 0.35 + 119401.25;
					_taxBracket = 35;    
				}

				if (_annualIncome > 413200) {
					finalTax = (_annualIncome - 413200) * 0.396 + 119996.25;
					_taxBracket = 39.6;    
				}

			}


			if (_filingStatus == 1) {


				if (_annualIncome <= 18450) {
					finalTax = _annualIncome * 0.10;    
					_taxBracket = 10;
				}

				if ((_annualIncome > 18450) && (_annualIncome <= 74900)) {
					finalTax = (_annualIncome - 18450) * 0.15 + 1845;
					_taxBracket = 15;    
				}

				if ((_annualIncome > 74900) && (_annualIncome <= 151200)) {
					finalTax = (_annualIncome - 74900) * 0.25 + 10312.50;
					_taxBracket = 25;    
				}

				if ((_annualIncome > 151200) && (_annualIncome <= 230450)) {
					finalTax = (_annualIncome - 151200) * 0.28 + 29387.50;
					_taxBracket = 28;    
				}

				if ((_annualIncome > 230450) && (_annualIncome <= 411500)) {
					finalTax = (_annualIncome - 230450) * 0.33 + 51577.50;
					_taxBracket = 33;    
				}

				if ((_annualIncome > 411500) && (_annualIncome <= 464850)) {
					finalTax = (_annualIncome - 411500) * 0.35 + 111324;
					_taxBracket = 35;    
				}

				if (_annualIncome > 464850) {
					finalTax = (_annualIncome - 464850) * 0.396 + 129996.50;
					_taxBracket = 39.6;    
				}

			}

			if (_filingStatus == 2) {


				if (_annualIncome <= 13150) {
					finalTax = _annualIncome * 0.10;    
					_taxBracket = 10;
				}

				if ((_annualIncome > 13150) && (_annualIncome <= 50200)) {
					finalTax = (_annualIncome - 13150) * 0.15 + 1315;
					_taxBracket = 15;    
				}

				if ((_annualIncome > 50200) && (_annualIncome <= 129600)) {
					finalTax = (_annualIncome - 50200) * 0.25 + 6872.50;
					_taxBracket = 25;    
				}

				if ((_annualIncome > 129600) && (_annualIncome <= 209850)) {
					finalTax = (_annualIncome - 129600) * 0.28 + 26772.50;
					_taxBracket = 28;    
				}

				if ((_annualIncome > 209850) && (_annualIncome <= 411500)) {
					finalTax = (_annualIncome - 209850) * 0.33 + 49192.50;
					_taxBracket = 33;    
				}

				if ((_annualIncome > 411500) && (_annualIncome <= 439000)) {
					finalTax = (_annualIncome - 411500) * 0.35 + 115737;
					_annualIncome = 35;    
				}

				if (_annualIncome > 439000) {
					finalTax = (_annualIncome - 439000) * 0.396 + 125362;
					_annualIncome = 39.6;    
				}



			}

			if (_filingStatus == 3) {


				if (_annualIncome <= 9225) {
					finalTax = _annualIncome * 0.10;    
					_taxBracket = 10;
				}

				if ((_annualIncome > 9225) && (_annualIncome <= 37450)) {
					finalTax = (_annualIncome - 9225) * 0.15 + 922.50;
					_taxBracket = 15;    
				}

				if ((_annualIncome > 37450) && (_annualIncome <= 75600)) {
					finalTax = (_annualIncome - 37450) * 0.25 + 5156.25;
					_taxBracket = 25;    
				}

				if ((_annualIncome > 75600) && (_annualIncome <= 115225)) {
					finalTax = (_annualIncome - 75600) * 0.28 + 14693.75;
					_taxBracket = 28;    
				}

				if ((_annualIncome > 115225) && (_annualIncome <= 205750)) {
					finalTax = (_annualIncome - 115225) * 0.33 + 25788.75;
					_taxBracket = 33;    
				}

				if ((_annualIncome > 205750) && (_annualIncome <= 232425)) {
					finalTax = (_annualIncome - 205750) * 0.35 + 55662;
					_taxBracket = 35;    
				}

				if (_annualIncome > 232425) {
					finalTax = (_annualIncome - 232425) * 0.396 + 64998.25;
					_taxBracket = 39.6;    
				}

			}


			if (finalTax <= 0) {
				_taxBracket = 0;
			}


			string taxString;

			taxString = string.Format("{0:C0}", finalTax) + " (" + _taxBracket + "% bracket)";


			return taxString;


		}


		public TaxCalc()
		{

			_buttonCommand = new SampleCommand(() => FederalTax = GetTax());

		}

		private ICommand _buttonCommand;
		public ICommand ButtonCommand {
			get { return _buttonCommand; }
		}


	}        

}