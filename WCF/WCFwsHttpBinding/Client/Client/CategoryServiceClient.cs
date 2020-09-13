using Contracts.DataContracts;
using Contracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Client
{
    public static class CategoryServiceClient
    {

        public static Category GetCategoryDetails(int categoryID)
        {
            Category category = new Category();

            WSHttpBinding myBinding = new WSHttpBinding();

            string strEndPointAddress =
                "http://localhost:7741/Services/CategoryServices/CategoryService";
            EndpointAddress myEndpoint = new EndpointAddress(strEndPointAddress);

            ChannelFactory<ICategoryService> myChannelFactory =
                new ChannelFactory<ICategoryService>(myBinding, myEndpoint);

            ICategoryService instance = myChannelFactory.CreateChannel();

            category = instance.GetCategoryDetails(categoryID);

            myChannelFactory.Close();

            return category;
        }

        public static string GetCategoryName(int categoryID)
        {
            string categoryName = string.Empty;
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.None; //安全级别
            EndpointAddress myEndpoint = new EndpointAddress("http://localhost:7741/CategoryServiceHost.svc");
            ChannelFactory<ICategoryService> myChannelFactory = new ChannelFactory<ICategoryService>(myBinding, myEndpoint);

            ICategoryService instance = myChannelFactory.CreateChannel();

            categoryName = instance.GetCategoryName(categoryID);

            myChannelFactory.Close();

            return categoryName;
        }

        public static Category GetCategoryString(string str)
        {
            Category category = new Category();

            WSHttpBinding myBinding = new WSHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress("http://localhost:7741/CategoryServiceHost.svc");
            ChannelFactory<ICategoryService> myChannelFactory = new ChannelFactory<ICategoryService>(myBinding, myEndpoint);

            ICategoryService instance = myChannelFactory.CreateChannel();

            category = instance.GetCategoryString(str);

            myChannelFactory.Close();

            return category;
        }

        public static Category GetCategorySelf(Category str)
        {
            Category category = new Category();

            WSHttpBinding myBinding = new WSHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress("http://localhost:7741/CategoryServiceHost.svc");
            ChannelFactory<ICategoryService> myChannelFactory = new ChannelFactory<ICategoryService>(myBinding, myEndpoint);

            ICategoryService instance = myChannelFactory.CreateChannel();

            category = instance.GetCategorySelf(str);

            myChannelFactory.Close();

            return category;
        }
    }
}
