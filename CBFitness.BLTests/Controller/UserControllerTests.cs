using Microsoft.VisualStudio.TestTools.UnitTesting;
using CBFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBFitness.BL.Model;

namespace CBFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        
        [TestMethod()]
        public void UserRegistrationTest()
        {
            //Arrange
            string userName = "Vasyl";  
            DateTime birthdate = DateTime.Now.AddYears(-18);
            Gender gender = new Gender("man");
            double weight = 100;
            double height = 190;
            //Act
            var controller = new UserController(userName, gender, birthdate, weight, height);
            var controller2 = new UserController(userName);
           
           
            
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthdate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(gender.Name, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);

        }

    }
}