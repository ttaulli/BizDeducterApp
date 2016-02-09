using System;
using BizDeducter.Database;
using System.Threading.Tasks;

namespace BizDeducter.Model
{



    public class Expense : BusinessEntityBase
    {
        //database fields
        public string Name { get; set; } = string.Empty;
        public double Amount { get; set; } = 0.00;
		public string SubType { get; set;} = "Miscellaneous";
        public string Purpose { get; set; } = string.Empty;
		public string Receipt { get; set; } = string.Empty;
		public string Who { get; set; } = string.Empty;
		public DateTime Date { get; set; } = DateTime.UtcNow; 

		public bool IsMileage { get; set; } = false;
		public string StartString { get; set; } = string.Empty;
		public double StartLatitude { get; set; } = 0;
		public double StartLongitude { get; set; } = 0;
		public string StopString { get; set; } = string.Empty;
		public double StopLatitude { get; set; } = 0;
		public double StopLongitude { get; set; } = 0;
		public bool RoundTrip { get; set; } = false;
		public double Miles { get; set; } = 0;

        //ignore as we don't want to save this, only for display
        [SQLite.Ignore]
        public string AmountDisplay => Amount.ToString("C");

        //Helper method to save expense
        public Task Save() => ExpensesDatabase.Current.SaveItem(this);
        public Task Delete() => ExpensesDatabase.Current.DeleteItem(this);

        public override string ToString()
        {
            return $"-{SubType}";
        }
    }
}

