using System;
using SQLite;
using Xamarin.Forms;
using BizDeducter.Helpers;
using BizDeducter.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizDeducter.Database
{
	public class CategoriesDatabase
	{
		static CategoriesDatabase current;
		public static CategoriesDatabase Current
		{
			get { return current ?? (current = new CategoriesDatabase()); }
		}

		SQLiteAsyncConnection Connection { get; }

		public CategoriesDatabase()
		{
			var location = "categoriesdb.db3";
			//using a dependency service to grab the folder to put 
			//database file
			var root = DependencyService.Get<IDatabaseHelper>().Root;
			location = System.IO.Path.Combine(root, location);
			Connection = new SQLiteAsyncConnection(location);

			//Create our table, could create tablesasync too
			Connection.CreateTableAsync<Category>().Wait();
		}


		public Task<T> GetItem<T>(int id) where T : IBusinessEntity, new()
		{
			return Connection.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();

		}

		public Task<List<T>> GetItems<T>() where T : IBusinessEntity, new()
		{

			return Connection.Table<T>().ToListAsync();

		}

		public Task<int> SaveItem<T>(T item) where T : IBusinessEntity
		{
			//Update or insert
			return item.Id != 0 ? 
				Connection.UpdateAsync(item) :
				Connection.InsertAsync(item);
		}

		public Task<int> SaveItems<T>(IEnumerable<T> items) where T : IBusinessEntity
		{
			return Connection.UpdateAllAsync(items);
		}

		public Task<int> DeleteItem<T>(T item) where T : IBusinessEntity, new()
		{
			return Connection.DeleteAsync(item);
		}
	}
}