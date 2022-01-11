using Domain;
using Storage;
using System;
using System.Collections.Generic;
using Xunit;

namespace StoreUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            //because of dependency inversion, you can create a random class that implements
            // the correct interface
            IDatabaseAccess mockDbAccess = new MockDbAccess();
            //THEN, use the "correct interface" implementing class that imlements those methods differently
            DataManager dataManager = new DataManager(mockDbAccess);

            //act
            //var result = dataManager.getActiveCustomer()

            //assert


            //List<Products> products = mockDbAccess.displayProducts1();

        }
    }
}
