using AdminCategoryService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminCategoryService.Manager
{
    public interface IManager
    {
        List<CategoryModel> GetAllCategories();
        List<SubCategoryModel> GetAllSubcategories();
        Task<bool> AddCategory(CategoryModel obj);
        Task<bool> AddSubcategory(SubCategoryModel obj);
        CategoryModel getCategoryid(int cid);
        SubCategoryModel getsubcategorybyid(int subid);
        bool DeletCategory(int cid);
        bool DeletSubCategory(int subid);
        bool updatecategory(CategoryModel obj);
        bool updatesubcategory(SubCategoryModel obj);
        List<SellerModel> GetAllSellers();
        List<UserModel> GetAllUsers();

    }
}
