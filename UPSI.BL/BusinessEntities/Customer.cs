using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.BusinessEntities
{
    public class Customer : ModelBase, ILoggable
    {

        public int BusinessEntityID { get; set; }
        public string UpsiCustomerNumber { get; set; }
        public string CustomerName { get; set; }


        public Customer()
        { }

        public override bool Validate()
        {
            var isValid = true;

            
            return isValid;
        }

        public string Log()
        {
            var logString = this.BusinessEntityID + ": Upsi Customer Number: " +
                            this.UpsiCustomerNumber + ": Upsi Customer Name: " +
                            this.CustomerName + ": Status: " +
                            this.EntityState.ToString();
            return logString;
        }
    }
}
