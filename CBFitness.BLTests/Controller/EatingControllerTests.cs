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
    public class EatingControllerTests
    {
         
        [TestMethod()]
        public void AddProductsTest()
        {
            //Arrange
            UserController userController = new UserController(new User());
            EatingController eatingController = new EatingController(userController.CurrentUser);


            var product = new Food();
            eatingController.AddProducts(product);
            //Act
            var food1 = eatingController.GettingFoodFromTheList(product.Name);
            //Assert
            Assert.AreEqual(food1.Name, product.Name);
            Assert.AreEqual(food1.Proteins, product.Proteins);
            Assert.AreEqual(food1.Fats, product.Fats);
            Assert.AreEqual(food1.Carbohydrates, product.Carbohydrates);
            Assert.AreEqual(food1.Calories, product.Calories);
        }
    }
}