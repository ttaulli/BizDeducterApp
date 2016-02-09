using System;
using BizDeducter.Database;
using System.Threading.Tasks;

namespace BizDeducter.Model
{



	public class Category : BusinessEntityBase
	{
		//database fields
		public string Name { get; set; } = "None";


		//Helper method to save expense
		public Task Save() => CategoriesDatabase.Current.SaveItem(this);
		public Task Delete() => CategoriesDatabase.Current.DeleteItem(this);


		public override string ToString()
		{
			return $"{Name}";
		}

	}
}