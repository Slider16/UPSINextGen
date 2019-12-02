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
    public class PersonRepository : IRepository<Person>
    {
        public PersonRepository()
        {

        }
        
        /// <summary>
        /// Saves a business entity to the database.
        /// </summary>
        /// <param name="_person"></param>
        /// <returns></returns>
        public bool Save(Person _person)
        {
            var success = false;

            //if (_person.HasChanges && _person.IsValid)
            //{
            //    if (_person.IsNew)
            //    {
            //       success = AddItem(_person);
            //    }
            //    else
            //    {
            //       success = UpdateItem(_person);
            //    }
            //}
            return success;
        }

        public int AddItem(Person _person)
        {
            // Call an INSERT Stored Procedure
            throw new NotImplementedException();
        }

        public Person GetItem(int key)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Person> GetItems(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Person _person)
        {
            // Call an UPDATE Stored Procedure
            throw new NotImplementedException();
        }

        public bool UpdateItems(ObservableCollection<Person> updatedPersons)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(Person _person)
        {
            throw new NotImplementedException();
        }


    }
}
