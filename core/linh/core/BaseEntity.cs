using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace linh.core
{
    #region BaseEntity
    [Serializable]
    public abstract class BaseEntityCollection<T> : List<T> where T : BaseEntity, new()
    {

    }
    [Serializable]
    public abstract class BaseEntity
    {
        public abstract BaseEntity getFromReader(IDataReader rd);
    }

    #endregion
}
