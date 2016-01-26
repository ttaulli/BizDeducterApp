using System;
using SQLite;
using BizDeducter.Model;

namespace BizDeducter.Database
{
    public class BusinessEntityBase :  ObservableObject, IBusinessEntity
    {
        public BusinessEntityBase()
        {
        }

        #region IBusinessEntity implementation

        [PrimaryKey, AutoIncrement] 
        public int Id
        {
            get; set;
        }

        #endregion
    }
}

