using System;
using BizDeducter.Database;
using System.Threading.Tasks;

namespace BizDeducter.Model
{
    public enum ExpenseType
    {
        Mileage,
        Meals,
        Other
    }

    public enum ExpenseSubType
    {
        Advertising,
        Car,
        Office,
        Repairs,
        Other,
		Meals
    }


    public class Expense : BusinessEntityBase
    {
        //database fields
        public string Name { get; set; } = string.Empty;
        public double Amount { get; set; } = 0.0;
        public ExpenseType ExpenseType { get; set; } = ExpenseType.Other;
        public ExpenseSubType SubType { get; set;} = ExpenseSubType.Meals;
        public string Purpose { get; set; } = string.Empty;
		public string Receipt { get; set; } = string.Empty;
		public string Who { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;


        //ignore as we don't want to save this, only for display
        [SQLite.Ignore]
        public string AmountDisplay => Amount.ToString("C");

        //Helper method to save expense
        public Task Save() => ExpensesDatabase.Current.SaveItem(this);
        public Task Delete() => ExpensesDatabase.Current.DeleteItem(this);

        public override string ToString()
        {
            return $"[{Receipt}";
        }
    }
}

