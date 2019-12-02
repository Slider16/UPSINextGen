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
    class ContactTypeRepository : IRepository<ContactType>
    {
        public bool Save(ContactType _contactType)
        {
            var success = false;

            //if (_contactType.HasChanges && _contactType.IsValid)
            //{
            //    if (_contactType.IsNew)
            //    {
            //        success = AddItem(_contactType);
            //    }
            //    else
            //    {
            //        success = UpdateItem(_contactType);
            //    }
            //}
            return success;
        }

        public int AddItem(ContactType _contactType)
        {
            throw new NotImplementedException();
        }

        public ContactType GetItem(int key)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<ContactType> GetItems(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(ContactType _contactType)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItems(ObservableCollection<ContactType> updatedContactTypes)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(ContactType _contactType)
        {
            throw new NotImplementedException();
        }

  
    }
}
