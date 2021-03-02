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
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void ExerciseControllerTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var actName = Guid.NewGuid().ToString();
            var usercontr = new UserController(userName);
            var excontr = new ExerciseController(usercontr.CurrentUser);
            var activity = new Activity(actName);
            //Act
            excontr.Add(activity, DateTime.Now, DateTime.Now.AddMinutes(1));
            //Assert
            Assert.AreEqual(actName,excontr.Activities.First().Name);
        }
    }
}