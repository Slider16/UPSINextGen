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
    public class AddressRepository : IRepository<Address>
    {
        public AddressRepository()
        {

        }

        /// <summary>
        /// Saves an address to the database.
        /// </summary>
        /// <param name="_address"></param>
        /// <returns></returns>
        public bool Save(Address _address)
        {
            var success = false;

            //if (_address.HasChanges && _address.IsValid)
            //{
            //    if (_address.IsNew)
            //    {
            //        success = AddItem(_address);
            //    }
            //    else
            //    {
            //        success = UpdateItem(_address);
            //    }
            //}
            return success;
        }

        public int AddItem(Address newItem)
        {
            // Call an INSERT Stored Procedure
            throw new NotImplementedException();
        }

        public Address GetItem(int key)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Address> GetItems(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Address _address)
        {
            // Call an UPDATE Stored Procedure
            throw new NotImplementedException();
        }

        public bool UpdateItems(ObservableCollection<Address> _updatedAddresses)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(Address _address)
        {
            throw new NotImplementedException();
        }


    }
}
