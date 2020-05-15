using AdminCategoryService.Entities;
using AdminCategoryService.Models;
using AdminCategoryService.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestAdminServices
{
    [TestFixture]
    class TestAdminRepository
    {
        AdminRepositoty _repo;
        DbContextOptionsBuilder<EmartDBContext> _builder;
        [SetUp]
        public void setup()
        {
            _builder = new DbContextOptionsBuilder<EmartDBContext>().EnableSensitiveDataLogging().UseInMemoryDatabase(Guid.NewGuid().ToString());
            EmartDBContext db = new EmartDBContext(_builder.Options);
            db.Category.Add(new Category { Cid = 641, Cname = "abc", Cdetails = "zyx" });
            db.Category.Add(new Category { Cid = 43, Cname = "abcef", Cdetails = "zyxfgg" });
            db.Category.Add(new Category { Cid = 642, Cname = "def", Cdetails = "wvu" });
            db.SubCategory.Add(new SubCategory { Subid = 1, Cid = 1, Subname = "abc", Sdetails = "adf", Gst = 6 });
            db.SubCategory.Add(new SubCategory { Subid = 2, Cid = 1, Subname = "abcd", Sdetails = "asdf", Gst = 6 });
            db.Seller.Add(new Seller { SellerId = 1, SellerName = "seller", KycAproval = "yes" });
            db.Seller.Add(new Seller { SellerId = 2, SellerName = "seller1", KycAproval = "No" });
            db.Users.Add(new Users { Userid = 1, Username = "user", Nooforders = 10, Failedorders = 5 });
            db.Users.Add(new Users { Userid = 2, Username = "user2", Nooforders = 10, Failedorders = 3 });
            db.SaveChanges();
    
            _repo = new AdminRepositoty(db);

        }
        [TearDown]
        public void Teardown()
        {
            _repo = null;
        }
             



        //Testing Add Category Success
        [Test]

        [Description("Add category")]
       // [TestCase(986, "dsa", "butterflow")]
        [TestCase(1, "dsa", "butterflow")]
        [TestCase(2, "dsaDG", "butter")]
        [TestCase(3, "dsaFSGA", "flow")]
        [TestCase(5, "dsaSF", "CELLO")]
        public async Task TestAddCategory_success(int Cid,string Cname,string Cdetails)
        {
            try
            {
               
                var cat = new CategoryModel(){ Cid =Cid, Cname = Cname, Cdetails = Cdetails };
                await _repo.AddCategory(cat);
                var res = _repo.getCategoryid(cat.Cid);
                Assert.NotNull(res);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }


        }

        [Test]
        [Description("Add Subcategory")]
        [TestCase(4,3, "dsa","butterflow", 3)]
        [TestCase(3,1, "dsa", "butterflow", 3)]
        public async Task TestAddsubcategory(int Subid, int Cid, string Sdetails, string Subname, int Gst)
        {
            try
            {
                SubCategoryModel sub = new SubCategoryModel();
                sub.Subid = Subid;
                sub.Cid = Cid;
                sub.Sdetails = Sdetails;
                sub.Subname = Subname;
                sub.Gst = Gst;
                await _repo.AddSubcategory(sub);

                var result = _repo.getsubcategorybyid(Subid);
                Assert.NotNull(result);
               
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        [Test]
        [TestCase(642)]
        [Description("Testing Getby id for category")]
        public void TestGetbycategory_success(int cid)
        {
            try
            {
                var result = _repo.getCategoryid(cid);
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        //Success TestCase
        [Test]
        [Description("Testing get by id for  Subcategory")]
        [TestCase(1)]
        public void TestGetbysubcategory_success(int subid)
        {

            var result = _repo.getsubcategorybyid(subid);
            Assert.NotNull(result);


        }
        //Testing Delete Category
        [Test]
        [Description("Testing delete by id for  category")]
        [TestCase(642)]
        public void TestDelete_Success(int Cid)
        {
            
              var result=  _repo.DeletCategory(Cid);
              Assert.AreEqual(true,result);
        
        }
        //Testing Delete subCategory
        [Test]
        [Description("Testing delete by id for  subcategory")]
     
        [TestCase(1)]
        public void TestDeleteSubcategory_Success(int subid)
        {
            try
            {
                var result=_repo.DeletSubCategory(subid);
                Assert.IsTrue(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [Test]
        [Description("Getcategorylist")]
        public void TestGetcategorylist()
        {
            
                var result = _repo.GetAllCategories();
            Assert.NotNull(result);
            Assert.GreaterOrEqual(result.Count,0);
        }
        [Test]
        [Description("GetUserslist")]
        public void TestGetUsersList()
        {
            try
            {
                var result = _repo.GetAllUsers();
                Assert.NotNull(result);
                Assert.GreaterOrEqual(result.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        [Test]
        [Description("GetSellerslist")]
        public void TestGetSellersList()
        {
            try
            {
                var result = _repo.GetAllSellers();
                Assert.NotNull(result);
                Assert.GreaterOrEqual(result.Count,0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }






        [Test]
        [Description("Getgetsubcategorylist")]
        public void TestGetsubcategorylist_success()
        {
            try
            {
                var result = _repo.GetAllSubcategories();
                Assert.NotNull(result);
                Assert.GreaterOrEqual(result.Count,0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        //Testing Update category
        [Test]
      
        public void UpdateCategory()
        {
            try
            {


                CategoryModel cat = new CategoryModel()
                {
                    Cid = 222,
                    Cname = "electronics",
                    Cdetails = "buy best of best",
                }; 
             var x= _repo.updatecategory(cat);
             Assert.True(x);
              

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
        //Testing update subcategory
       // int Subid, int Cid, string Sdetails, string Subname, int Gst
        [Test]
       // [TestCase(2,1,"lkj","cell",5)]
        [Description("update subCategory")]
        public void UpdateSubCategory()
        {
            try
            {
                SubCategoryModel subcat = new SubCategoryModel
                {
                    Subid = 2,
                    Subname = "hjdf",
                    Cid = 3,
                    Sdetails = "asf",
                    Gst = 6,
                };
               var result=_repo.updatesubcategory(subcat);
                Assert.True(result);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
      

    }
}
