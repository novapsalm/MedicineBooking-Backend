using DailyDose1.Controllers;
using DailyDose1.Models;
using DailyDose1.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepo>();

            mockRepo.Setup(x => x.GetAllUsers()).ReturnsAsync(GetAllU);
            var controller = new UserController(mockRepo.Object);
            ActionResult p = await controller.GetUser();
            Assert.IsType<OkObjectResult>(p);
        }

        [Fact]
        public async void Test2()
        {
            //Arrange
            var mockRepo = new Mock<IMedRepo>();
            mockRepo.Setup(x => x.GetAllMedicine()).ReturnsAsync(GetAllM);
            var controller = new MedicineController(mockRepo.Object);
            ActionResult p = await controller.GetMedicine();
            Assert.IsType<OkObjectResult>(p);
        }

        [Fact]
        public async void Test3()
        {
            //Arrange
            var mockRepo = new Mock<ICartRepo>();

            mockRepo.Setup(x => x.GetAllCart()).ReturnsAsync(GetAllC);
            var controller = new CartController(mockRepo.Object);
            ActionResult p = await controller.GetCart();
            Assert.IsType<OkObjectResult>(p);
        }


        public List<Users> GetAllU()
        {
            List<Users> users = new List<Users>();
            users.Add(new Users
            {
                Id = 1,
                FirstName = "firstname",
                LastName = "lastname",
                Email = "example@gmail.com",
                Password = "password",
                Type = "user",
                CreatedOn = DateTime.Now
            });
            users.Add(new Users
            {
                Id = 2,
                FirstName = "firstname2",
                LastName = "lastname2",
                Email = "example2@gmail.com",
                Password = "password2",
                Type = "admin",
                CreatedOn = DateTime.Now
            });
            return users;
        }

        public List<Medicine> GetAllM()
        {
            List<Medicine> users = new List<Medicine>();
            users.Add(new Medicine
            {
                Id = 1,
                Name = "Name",
                Descriptions = "Description1",
                Manufacturer = "Manufacturer1",
                UnitPrice = 1,
                Quantity = 1,
                ExpDate = DateTime.Now,
            });
            users.Add(new Medicine
            {
                Id = 2,
                Name = "Name2",
                Descriptions = "Description12",
                Manufacturer = "Manufacturer12",
                UnitPrice = 12,
                Quantity = 12,
                ExpDate = DateTime.Now,
            });
            return users;
        }

        public List<Cart> GetAllC()
        {
            List<Cart> users = new List<Cart>();
            users.Add(new Cart
            {
                Id = 1,
                UserId = 1,
                MedicineId = 1,
                UnitPrice = 1,
                Quantity = 1,
                TotalPrice = 1,
            });
            users.Add(new Cart
            {
                Id = 2,
                UserId = 2,
                MedicineId = 2,
                UnitPrice = 2,
                Quantity = 2,
                TotalPrice = 2,
            });
            return users;
        }
    }
}