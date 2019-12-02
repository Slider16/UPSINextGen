using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Interfaces
{

    /// <summary>
    /// Interface for all repositories for all entities to handle basic CRUD operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        bool Save(T item);

        int AddItem(T item);

        T GetItem(int key);

        ObservableCollection<T> GetItems(bool includeDeleted=false);

        bool UpdateItem(T item);

        bool UpdateItems(ObservableCollection<T> updatedItems);
                
        bool DeleteItem(T item);
    }
}
