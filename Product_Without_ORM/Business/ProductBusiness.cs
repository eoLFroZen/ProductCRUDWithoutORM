using Product_Without_ORM.Data;
using Product_Without_ORM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Without_ORM.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductData productData;

        public ProductBusiness(IProductData productData)
        {
            this.productData = productData;
        }

        public List<Product> GetAll()
        {
            return this.productData.GetAll();
        }

        public Product GetById(int id)
        {
            return this.productData.GetById(id);
        }

        public void Add(Product product)
        {
            this.productData.Add(product);
        }

        public void Update(Product product)
        {
            this.productData.Update(product);
        }
        public void Delete(int id)
        {
            this.productData.Delete(id);
        }

    }
}
