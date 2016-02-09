using System;

namespace BizDeducter.Model
{

    public enum PageId
    {
        Home,
        Expenses,
        Reports,
		TaxCalendar,
		TaxBracket
    }

    public class NavigationItem
    {
       
        public PageId Id { get; set;} = PageId.Home;
        public string Name { get; set;} = string.Empty;

        public override string ToString()
        {
            return Name;
        }
    }
}

