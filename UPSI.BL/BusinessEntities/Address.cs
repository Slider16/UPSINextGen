using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.BusinessEntities
{
    public class Address : ModelBase, ILoggable
    {
        public int AddressId { get; private set; }
        public int BusinessEntityID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceID { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Address()
        { }

        public Address(int addressId)
        {
            this.AddressId = addressId;
        }


        /// <summary>
        /// Validates an address
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        public string Log()
        {
            var logString = this.AddressId.ToString() + ": BusinessEntityID: " +
                            this.BusinessEntityID.ToString() + ": Date Modified: " +
                            this.ModifiedDate.ToLongTimeString() + ": Street Address: " +
                            this.AddressLine1;
            return logString;
        }
    }
}
