using AdminCategoryService.Manager;
using AdminCategoryService.Models;
using AdminCategoryService.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestAdminServices
{
    class TestAdminManager
    {
       AdminManager _manager;
        Mock<IAdminRepository> _iadmin;
        
        [SetUp]
        public void setup()
        {
     
            _iadmin = new Mock<IAdminRepository>();
            _manager = new AdminManager(_iadmin.Object);

        }
        [TearDown]
        public void Teardown()
        {
            _manager = null;
        }

        //Testing Add Category Success
        [Test]
        [Description("get category")]
        [TestCase(906,"electronics","electric gadgets")]
        [TestCase(907,"clothings","Wholesale")]
        [TestCase(908,"HomeNeeds","All home needies")]
        public async Task TestAddCategory_success(int cid, string cname, string cdetails)
        {
            try
            {
                CategoryModel cat = new CategoryModel
                {
                    Cid = cid,
                    Cname = cname,
                    Cdetails = cdetails
                };
               _iadmin.Setup(x => x.AddCategory(cat)).ReturnsAsync(true);
                AdminManager mg = new AdminManager(_iadmin.Object);
                var res= await mg.AddCategory(cat);
                Assert.AreEqual(true,res);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }



        }

        [Test]
        [Description("Add Subcategory")]
        [TestCase(903, 2, "def", "pens", 4)]
        [TestCase(904, 1, "lkj", "cello", 5)]
        [TestCase(905, 1, "dsa", "butterflow", 3)]
        public async Task TestAddsubcategory(int Subid, int Cid, string Sdetails, string Subname, int Gst)
        {
            try
            {
                 SubCategoryModel subcat= new SubCategoryModel
                {
                    Subid = Subid,
                    Cid = Cid,
                    Sdetails = Sdetails,
                    Subname = Subname,
                    Gst = Gst,
                };
                _iadmin.Setup(x => x.AddSubcategory(subcat)).ReturnsAsync(true);
                AdminManager mg = new AdminManager(_iadmin.Object);
                var result =await  mg.AddSubcategory(subcat);
                Assert.AreEqual(true, result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        [Test]
        [Description("Testing Getby id for category")]
        [TestCase(1)]
        [TestCase(2)]
        public void TestGetbycategory_success(int Cid)
        {
            try
            {
                CategoryModel cat = new CategoryModel();
                _iadmin.Setup(x => x.getCategoryid(Cid)).Returns(cat);
                var result = _manager.getCategoryid(Cid);
                Assert.AreEqual(cat, result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        //Failure Test Cases
        [Test]
        [TestCase(1,999)]
        [TestCase(2,888)]
        public void TestGetbycategory_Failure(int cid,int Cid)
        {

            CategoryModel cat = new CategoryModel();
            _iadmin.Setup(x => x.getCategoryid(cid)).Returns(cat);
            var result = _manager.getCategoryid(Cid);
            Assert.AreNotEqual(cat, result);
        }



        //Success TestCase
        [Test]
        [Description("Testing get by id for  Subcategory")]
        [TestCase(93)]
        [TestCase(94)]
        public void TestGetbysubcategory_success(int Subid)
        {
            try
            {

                SubCategoryModel subcat = new SubCategoryModel();
                _iadmin.Setup(x => x.getsubcategorybyid(Subid)).Returns(subcat);
                AdminManager mg = new AdminManager(_iadmin.Object);
                var result = mg.getsubcategorybyid(Subid);
                Assert.AreEqual(subcat,result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        //Failure TestCase
        [Test]
        [Description("Testing get by id for  Subcategory")]
        [TestCase(1000,93)]
        [TestCase(1002,94)]
        public void TestGetbysubcategory_Failure(int subid,int Subid)
        {
            try
            {
                SubCategoryModel subcat = new SubCategoryModel();
                _iadmin.Setup(x => x.getsubcategorybyid(subid)).Returns(subcat);
                AdminManager mg = new AdminManager(_iadmin.Object);
                var result = mg.getsubcategorybyid(Subid);
                Assert.AreNotEqual(subcat, result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        //Testing Delete Category
        [Test]
        [Description("Testing delete by id for  category")]
        [TestCase(16)]
        public void TestDelete_Success(int cid)
        {
            try
            {
                _manager.DeletCategory(cid);
                var result = _manager.getCategoryid(cid);
                Assert.IsNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        //Testing Delete subCategory
        [Test]
        [Description("Testing delete by id for  subcategory")]
      
        [TestCase(86)]
        public void TestDeleteSubcategory_Success(int subid)
        {
            try
            {
                _manager.DeletSubCategory(subid);
                var result = _manager.getsubcategorybyid(subid);
                Assert.IsNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        //Get All category
        [Test]
        [Description("Getcategorylist")]
        public void TestGetcategorylist()
        {
            try
            {
                List<CategoryModel> cat = new List<CategoryModel>();
                _iadmin.Setup(x => x.GetAllCategories()).Returns(cat);
                AdminManager mg = new AdminManager(_iadmin.Object);
                var result = mg.GetAllCategories();
                Assert.AreEqual(cat,result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        //Test all USersLIst
        [Test]
        [Description("GetUserslist")]
        public void TestGetUserslist()
        {
            try
            {
                List<UserModel> user = new List<UserModel>();
                _iadmin.Setup(x => x.GetAllUsers()).Returns(user);
                AdminManager mg = new AdminManager(_iadmin.Object);
                var result = mg.GetAllUsers();
                Assert.AreEqual(user,result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        //Test All Sellers 
        [Test]
        [Description("GetSellerlist")]
        public void TestGetsellerlist()
        {
            try
            {
                List<SellerModel> seller = new List<SellerModel>();
                _iadmin.Setup(x => x.GetAllSellers()).Returns(seller);
                AdminManager mg = new AdminManager(_iadmin.Object);
                var result = mg.GetAllSellers();
                Assert.AreEqual(seller, result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        //Test ALL subCategory LIst
        [Test]
        [Description("Getgetsubcategorylist")]
        public void TestGetsubcategorylist_success()
        {
            try
            {
                List<SubCategoryModel> sub = new List<SubCategoryModel>();
                _iadmin.Setup(x => x.GetAllSubcategories()).Returns(sub);
                AdminManager mg = new AdminManager(_iadmin.Object);
                var result = mg.GetAllSubcategories();
                Assert.AreEqual(sub,result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        // MOck add data to category
        [Test]
        [Description("to test the mock data")]
        public void AddMockCategory()
        {
            try
            {
                var cId = 93;
                var cName = "books";
                var CDetail = "all books";
                var cat = new CategoryModel { Cid = cId, Cname = cName, Cdetails = CDetail };
                var mock = new Mock<IManager>();
                mock.Setup(x => x.AddCategory(cat));
                var result = mock.Setup(x => x.getCategoryid(cat.Cid));
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }


        }
        //Testing update subcategory
        [Test]
        [TestCase(1113, 2, "def", "pen", 4)]
        [TestCase(3, 1, "dsa", "butter", 3)]
        [Description("update subCategory")]
        public void UpdateSubCategory(int Subid, int Cid, string Sdetails, string Subname, int Gst)
        {
            try
            {
                SubCategoryModel subcat = new SubCategoryModel() {  Subid=Subid };
                var mock = new Mock<IAdminRepository>();
                mock.Setup(x => x.updatesubcategory(subcat)).Returns(true);
                AdminManager mg = new AdminManager(mock.Object);
                var result =mg.updatesubcategory(subcat);
                Assert.IsNotNull(result);
                Assert.AreEqual(true,result);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        //update category
        [Test]
        [Description("testing buyer update category")]
        public void updatecategory_Successfull()
        {
            try
            {
                CategoryModel cat = new CategoryModel() { Cid = 2};
                var mock = new Mock<IAdminRepository>();
                mock.Setup(x => x.updatecategory(cat)).Returns(true);
                AdminManager mg = new AdminManager(mock.Object);
                var result = mg.updatecategory(cat);
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
