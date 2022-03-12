using Product_Without_ORM.Business;
using Product_Without_ORM.Data;
using Product_Without_ORM.Presentation;
using System;

namespace Product_Without_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductData productData = new ProductData();

            ProductBusiness productBusiness = new ProductBusiness(productData);

            Display display = new Display(productBusiness);
        }
    }
}
