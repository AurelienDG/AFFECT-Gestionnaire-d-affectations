using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_prototype;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAE_prototype.Tests
{
    [TestClass()]
    public class AffectationTests
    {
        private Affectation a1;
        private Affectation a2;

        [TestMethod()]
        public void AFFECTATIONTest()
        {
            this.a1 = new Affectation();
            this.a1 = new Affectation(new Division(), new Mission(), new DateTime(2022, 06, 17));
            this.a1 = new Affectation(new Division(), new Mission(), new DateTime(2022,05,13), "ceci est un commentaire");


        }

        [TestMethod()]
        public void UpdateTest()
        {
            this.a1 = new Affectation(new Division(), new Mission(), new DateTime(2022, 05, 14));
            this.a1.DateMission = new DateTime(2004, 05, 14);
            this.a1.Commentaire = "slt";
            this.a1.Update();
        }
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException), "L'affectation a été mal instancié")]
        public void UpdateTestSansAffectation()
        {
            this.a1.DateMission = new DateTime(2012, 02, 04);
            this.a1.Commentaire = "slt";
            this.a1.Update();
        }

        [TestMethod()]
        public void CreateTest()
        {
            this.a1 = new Affectation(new Division(), new Mission(), new DateTime(2022, 05, 13));
            this.a1.Create();
            this.a2 = new Affectation(new Division(), new Mission(), new DateTime(2022, 06, 14),"commentaire");
            this.a2.Create();

        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException), "L'affectation a été mal instancié")]
        public void CreateTestAvecAffectationMalInstancié()
        {
            this.a1.Create();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            this.a1 = new Affectation(new Division(), new Mission(), new DateTime(2022, 05, 13));
            this.a1.Delete();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException), "L'affectation a été mal instancié")]
        public void DeleteTestSansAffectation()
        {
            this.a1.Delete();
        }

        [TestMethod()]
        public void FindAllTest()
        {

        }

        [TestMethod()]
        public void FindBySelectionTest()
        {

        }

        [TestMethod()]
        public void ReadTest()
        {

        }
    }
}