using AdminCategoryService.Controllers;
using AdminCategoryService.Manager;
using AdminCategoryService.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace TestAdminServices
{
    [TestFixture]
    class TestAdminController
    {
        private AdminServiceController controller;
         Mock<IManager> manager;
        [SetUp]
        public void SetUp()
        {
            var logger = new Mock<ILogger<AdminServiceController>>();
           manager = new Mock<IManager>();
            controller = new AdminServiceController(manager.Object, logger.Object);


        }
        [Test]
        [TestCase(956, "HomeNeeds", "All home needies")]
        public void TestAddcategory(int cid, string cname, string cdetails)
        {
            try
            {
                CategoryModel cat = new CategoryModel { Cid = cid, Cname = cname, Cdetails = cdetails };
                var mock = new Mock<IManager>();
                mock.Setup(x => x.AddCategory(cat)).ReturnsAsync(true);
                var res =controller.getcategory(cid);
                Assert.NotNull(res);
               



            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        [Test]
        [TestCase(612, "HomeNeeds",1, "All",4)]
        public void TestAddSubcategory(int subid, string subname,int cid, string sdetails,int gst)
        {
            try
            {
                SubCategoryModel subcat = new SubCategoryModel() {Subid=subid,Subname=subname,Cid = cid,Sdetails=sdetails,Gst=gst};
                var mock = new Mock<IManager>();
                mock.Setup(x => x.AddSubcategory(subcat)).ReturnsAsync(true);
                var res = controller.getcategory(subcat.Subid);
                Assert.NotNull(res);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        [Test]
        [Description("Testing Getby id for category")]
        [TestCase(1)]
        public void TestGetbycategory_success(int cid)
        {
            try
            {
                var result = controller.getcategory(cid);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        [Test]
        [Description("Testing Getby id for subcategory")]
        [TestCase(2)]
        [TestCase(1)]
        public void TestGetbysubcategory_success(int subcid)
        {
            try
            {
                var result =controller.getcategory(subcid);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }


        [Test]
        [Description("Testing delete category")]
        [TestCase(20)]
        public void TestDeleteCategory(int cid)
        {
            try
            {
               
                var x= controller.DeleteCategory(cid);
                Assert.IsNotNull(x);
               




            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        [Test]
        [Description("Testing delete subcategory")]
        [TestCase(58)]
        public void TestDeleteSubCategory(int subid)
        {
            try
            {
               var x= controller.DeleteSubCategory(subid);
                Assert.IsNotNull(x);


            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        [Test]
        [Description("Testing Get All user")]
        public void TestGetAllUsers()
        {
            try
            {
                var x = controller.GetUsers();
                Assert.IsNotNull(x);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        [Test]
        [Description("Testing Get All sellers")]
        public void TestGetAllSeller()
        {
            try
            {
                var x = controller.GetSellers();
                Assert.IsNotNull(x);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        [Test]
        [TestCase(589, "Home", "All home needies")]
        public void TestUpdateCategory(int cid, string cname, string cdetails)
        {
            try
            {
                CategoryModel cat = new CategoryModel { Cid = cid, Cname = cname, Cdetails = cdetails };
                var res = controller.updatecategory(cat);
                Assert.NotNull(res);




            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }


        [Test]
        [TestCase(612, "Home", 1, "All", 4)]
        public void TestUpdateSubcategory(int subid, string subname, int cid, string sdetails, int gst)
        {
            try
            {
                SubCategoryModel subcat = new SubCategoryModel() { Subid = subid, Subname = subname, Cid = cid, Sdetails = sdetails, Gst = gst };
                var res = controller.updatesubcategory(subcat);
                Assert.NotNull(res);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }


    }

}