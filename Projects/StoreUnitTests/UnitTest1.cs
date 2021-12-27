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

            MockDbAccess mockDbAccess = new MockDbAccess();
            DatabaseAccess databaseAccess = new DatabaseAccess();


            //List<Products> products = mockDbAccess.displayProducts1();

        }
    }
}
