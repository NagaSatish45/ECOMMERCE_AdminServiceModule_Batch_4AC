using AdminCategoryService.Models;
using AdminCategoryService.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminCategoryService.Manager
{
    public class AdminManager:IManager
    {

        public readonly IAdminRepository _repo;

        public AdminManager(IAdminRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddCategory(CategoryModel obj)
        {
            try
            {
                await _repo.AddCategory(obj);
                  return true;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> AddSubcategory(SubCategoryModel obj)
        {
               await _repo.AddSubcategory(obj);
                return true;
           
        }

        public bool DeletCategory(int cid)
        {
            CategoryModel cat = new CategoryModel { Cid = cid };
           _repo.DeletCategory(cat.Cid);
            if (cat.Cid==0)
                return false;
            else
                return true;
        }

        public bool DeletSubCategory(int subid)
        {
            _repo.DeletSubCategory(subid);
            return true;
        }

        public List<CategoryModel> GetAllCategories()
        {
            try
            {
                List<CategoryModel> cat = _repo.GetAllCategories();
                return cat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SellerModel> GetAllSellers()
        {
            List<SellerModel> seller = _repo.GetAllSellers();
            return seller;
        }

        public List<SubCategoryModel> GetAllSubcategories()
        {
            try
            {
                List<SubCategoryModel> subcat = _repo.GetAllSubcategories();
                    return subcat;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = _repo.GetAllUsers();
            return users;
        }

        public CategoryModel getCategoryid(int cid)
        {
            try
            {
                CategoryModel cat = _repo.getCategoryid(cid);
                if (cat == null)
                {
                    return null;
                }
                else
                {
                    return cat;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public SubCategoryModel getsubcategorybyid(int subid)
        {
            try
            {
                SubCategoryModel subcat = _repo.getsubcategorybyid(subid);
                if (subcat == null)
                {
                    return null;
                }
                else
                    return subcat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updatecategory(CategoryModel obj)
        {
            try
            {
                bool cat =_repo.updatecategory(obj);
                if (cat)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updatesubcategory(SubCategoryModel obj)
        {
            try
            {
                bool subcat =_repo.updatesubcategory(obj);
                if (subcat)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
