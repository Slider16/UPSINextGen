using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UPSI.BL.BusinessEntities
{
    public class Person : ModelBase
    {
        public static int InstanceCount { get; set; }

        public int BusinessEntityID { get; private set; }
        public string PersonType { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }

        public List<Address> Addresses { get; set; }
        public List<EmailAddress> EmailAddresses { get; set; }

        
        
        public string FullName
        {
            get 
            {
                string fullname = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullname))
                    {
                        fullname += ", ";
                    }
                    fullname += FirstName;
                }
                return fullname;
            }
        }

        public Person()
        {
            
        }

        public Person(int businessEntityID)
        {
            this.BusinessEntityID = businessEntityID;
        }



        /// <summary>
        /// Validates that the required LastName is entered.
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            var isValid = !string.IsNullOrWhiteSpace(LastName);

            return isValid;
        }





    }
}
