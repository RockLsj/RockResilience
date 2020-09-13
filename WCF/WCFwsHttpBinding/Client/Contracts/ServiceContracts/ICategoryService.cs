using Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Contracts.ServiceContracts
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
