using Contracts.DataContract;
using System.ServiceModel;

namespace Contracts.ServiceContract
{
    [ServiceContract(Name = "CategoryService", Namespace = "http://rock.com/categoryservice")]
    public interface ICategoryService
    {
        [OperationContract]
        string GetCategoryName(int categoryID);

        [OperationContract]
        Category GetCategoryDetails(int categoryID);

        [OperationContract]
        Category GetCategoryString(string str);

        [OperationContract]
        Category GetCategorySelf(Category str);
    }
}
