using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using AccesConcurrents;

namespace TestUnitAccesConcurrents
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddDatabase()
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<CompanyContext>());

            //AAA
            //1. Arrange => on instancie
            CompanyContext companyCtx = new CompanyContext();
            Customer customer = new Customer();

            customer.AccountBalance = 111.11;
            customer.AddressLine1 = "Rue des Chevaux 12";
            customer.AddressLine2 = "Rue des Anes 13";
            customer.City = "Namur";
            customer.Country = "Belgique";
            customer.Email = "quentinveys@gmail.com";
            customer.Id = 1;
            customer.Name = "Quentin";
            customer.PostCode = "5000";
            customer.Remark = "Just Perfect!";

            companyCtx.Customers.Add(customer);

            //2. Act => on utilise le système

            companyCtx.SaveChanges();

            //3. Assert => on compare le résultat obtenu et attendu
            verifyDatabaseIsNotEmpty();
        }

        public void verifyDatabaseIsNotEmpty()
        {
            CompanyContext companyCtx = new CompanyContext();
            int count = Convert.ToInt32(companyCtx.Customers.CountAsync());
            Assert.IsTrue(count > 0);
        }
    }
}
