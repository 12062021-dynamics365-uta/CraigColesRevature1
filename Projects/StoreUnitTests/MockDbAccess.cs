using Domain;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreUnitTests
{
    public class MockDbAccess : IDatabaseAccess
    {
        public void displayActiveCustomers()
        {
            int CustomerID = 0;
            CustomerID = this._databaseAccess.getActiveCustomerID(FirstName, LastName);
        }

       
    }
}
