using Contracts.DataContracts;
using Contracts.ServiceContracts;
using System.ServiceModel;

//rock lsj
namespace Services.CategoryServices
{
    [ServiceBehavior(Name = "CategoryService", Namespace = "http://rock.com/categoryservice")]
    public class CategoryService : ICategoryService
    {
        public string GetCategoryName(int categoryID)
        {
            return "GetCategoryName " + categoryID;
        }

        public Category GetCategoryDetails(int categoryID)
        {
            Category category = new Category();

            category.CategoryID = categoryID;
            category.CategoryName = "CategoryName " + categoryID;
            category.CategoryDescription = "Hello " + categoryID;
            category.CategoryURL = "baiu.com " + categoryID;

            return category;
        }

        public Category GetCategoryString(string str)
        {
            Category category = new Category();
            category.CategoryID = 1;
            category.CategoryName = "1223";
            category.CategoryDescription = "1234456";
            category.CategoryURL = "http://northwind.com/Beverages";

            return category;
        }

        public Category GetCategorySelf(Category ca)
        {
            //ca.CategoryID = 1;
            //ca.CategoryName = "test";
            //ca.CategoryDescription = "12311111114456";
            //ca.CategoryURL = "http://northwind.com/Beverages";


            return ca;
        }
    }
}
