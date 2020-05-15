using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdminCategoryService.Manager;
using AdminCategoryService.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminCategoryService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminServiceController : ControllerBase
    {

        private readonly IManager _manager;
        private readonly ILogger<AdminServiceController> _logger;


        public AdminServiceController(IManager manager, ILogger<AdminServiceController> logger)//Constructor
        {
            _logger = logger;
            _manager = manager;
        }
        //Adding Category
        // <summary>
        // To Add a new category to a table in EmartDB database
        // </summary>
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> Addcategory(CategoryModel obj)
        {

            var x = await _manager.AddCategory(obj);
            if (x)
            {
                return Ok("Category Added");
            }
            else
                return null;
            throw new Exception("Exception while adding  the categories to the storage.");

        }

        //Adding Subcategory
        // <summary>
        // To Add a new subcategory to a table in EmartDB database
        // </summary>
        [HttpPost]
        [Route("AddSubCategory")]
        public async Task<IActionResult> Addsubcategory(SubCategoryModel obj)
        {
            bool x = await _manager.AddSubcategory(obj);
            if (x)
            {
                return Ok("Category Added");
            }
            else
                return null;
            throw new Exception("Exception while adding the subcategory  to the storage.");


        }
        //Fetching Category by id
        // <summary>
        // fetching a category from the table in EmartDB database
        // </summary>
        [HttpGet]
        [Route("getcategory/{cid}")]
        public IActionResult getcategory(int cid)
        {
            //try and catch block using Global Exception handling 
            //implementing logging
            var x = _manager.getCategoryid(cid);
            _logger.LogInformation("fetching categories by id");
            return Ok(x);
            
            throw new Exception("Exception while fetching  the categories from the storage.");



        }
        //fetching sub category by id
        // <summary>
        // fetching a subcategory from the table in EmartDB database
        // </summary>
        [HttpGet]
        [Route("getsubcategory/{subid}")]
        public IActionResult getsubcategory(int subid)
        {
            _logger.LogInformation("fetching   subcategories by id: ");
            var x=_manager.getsubcategorybyid(subid);
            return Ok(x);
            throw new Exception("Exception while fetching  the subcategories from the storage.");

        }
        //Getting all the Category
        // <summary>
        // fetching all category from the table in EmartDB database
        // </summary>
        [HttpGet]
        [Route("GetAllCategory")]
        public IActionResult GetAllCategories()
        {


            var category = _manager.GetAllCategories();
            _logger.LogInformation($"Returning {category.Count} categories.");
            return Ok(category);
            throw new Exception("Exception while fetching all the subcategories from the storage.");


        }
        //Getting list of all the sub categories
        // <summary>
        // fetching all subcategory from the table in EmartDB database
        // </summary>
        [HttpGet]
        [Route("GetAllSubcategory")]
        public IActionResult GetSubcategories()
        {

            _logger.LogInformation("fetching  all subcategories");
            var subcategory = _manager.GetAllSubcategories();
            return Ok(subcategory);
            throw new Exception("Exception while fetching all the subcategories from the storage.");

        }
        //Deleting category
        // <summary>
        // Deleting  a category from the table in EmartDB database
        // </summary>
        [HttpDelete]
        [Route("DeleteCategory/{cid}")]
        public IActionResult DeleteCategory(int cid)
        {
           _manager.DeletCategory(cid);
           return Ok("Category Deleted"); 
            throw new Exception("Exception while deleting a category from the storage.");
        }

        //deleting sub category
        // <summary>
        // Deleting  a subcategory from the table in EmartDB database
        // </summary>
        [HttpDelete]
        [Route("DeleteSubCategory/{subid}")]
        public IActionResult DeleteSubCategory(int subid)
        {
             _manager.DeletSubCategory(subid);
             return Ok("subcategory deleted");
           
            throw new Exception("Exception while deleting a subcategories from the storage.");


        }
        //updating category
        // <summary>
        // updating a category from the table in EmartDB database
        // </summary>

        [HttpPut]
        [Route("updatecategory")]
        public IActionResult updatecategory(CategoryModel obj)
        {

            _manager.updatecategory(obj);
             return Ok("updated");
            throw new Exception("Exception while updating a category t0 the storage.");
        }
        //updating the subcategory
        // <summary>
        // updating  a subcategory from the table in EmartDB database
        // </summary>
        [HttpPut]
        [Route("updatesubcategory")]
        public IActionResult updatesubcategory(SubCategoryModel obj)
        {

            _manager.updatesubcategory(obj);
           return Ok("updated");
            throw new Exception("Exception while updating subcategory to the storage.");




        }

        //Get all Users
        // <summary>
        //Get all users from data base
        // </summary>
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetUsers()
        {


            var users = _manager.GetAllUsers();
            return Ok(users);
            throw new Exception("Exception while fetching all the users from the storage.");


        }
        //Get all sellers
        // <summary>
        //Get all sellers from data base
        // </summary>
        [HttpGet]
        [Route("GetAllSellers")]
        public IActionResult GetSellers()
        {


            var seller = _manager.GetAllSellers();
            return Ok(seller);
            throw new Exception("Exception while fetching all the sellers from the storage.");


        }

    }
}