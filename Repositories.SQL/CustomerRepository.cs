using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPSI.BL.BusinessEntities;

namespace Repositories.SQL
{
    public class CustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Saves a Customer entity to the database.
        /// </summary>
        /// <param name="_customer"></param>
        /// <returns></returns>
        public bool Save(Customer _customer)
        {
            var success = false;

            //if (_customer.HasChanges && _customer.IsValid)
            //{
            //    if (_customer.IsNew)
            //    {
            //        success = AddItem(_customer);
            //    }
            //    else
            //    {
            //        success = UpdateItem(_customer);
            //    }
            //}
            return success;
        }

        public int AddItem(Customer _customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetItem(int key)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Customer> GetItems(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Customer _customer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItems(ObservableCollection<Customer> _updatedCustomers)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(Customer _customer)
        {
            throw new NotImplementedException();
        }


    }
}
