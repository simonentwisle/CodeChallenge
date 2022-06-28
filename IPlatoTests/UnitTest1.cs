using IPlatoCodeChallenge.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IPlatoTests
{
    [TestClass]
    public class IsPersonNull
    {
        [TestMethod]
        public void TestMethod1()
        {
            PersonViewModel sViewModel = new PersonViewModel();
            var person = sViewModel.SelectedPerson;
            Assert.IsNull(person);
        }
    }
}
