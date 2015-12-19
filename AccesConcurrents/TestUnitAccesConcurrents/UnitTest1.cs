using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using AccesConcurrents;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace TestUnitAccesConcurrents
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InsertionFonctionnelle()
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
            int count = companyCtx.Customers.Count();
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DetecteLesEditionsConcurrentes()
        {
            var contexteDeJohn = new CompanyContext();
            var clientDeJohn = contexteDeJohn.Customers.First();

            var contexteDeSarah = new CompanyContext();
            var clientDeSarah = contexteDeSarah.Customers.First();

            clientDeJohn.AccountBalance += 11;
            contexteDeJohn.SaveChanges();

            clientDeSarah.AccountBalance += 100;
            contexteDeSarah.SaveChanges();
        }
    
    }
}
