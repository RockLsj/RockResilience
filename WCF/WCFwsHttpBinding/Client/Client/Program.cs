using Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Category category = CategoryServiceClient.GetCategoryDetails(3333);
            Console.WriteLine(category.CategoryID);
            Console.WriteLine(category.CategoryName);
            Console.WriteLine(category.CategoryDescription);
            Console.WriteLine(category.CategoryURL);
            Console.WriteLine();
        }
    }
}
