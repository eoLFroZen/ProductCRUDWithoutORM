using Product_Without_ORM.Data.Entities;
using System.Collections.Generic;

namespace Product_Without_ORM.Data
{
    public interface IProductData
    {
        List<Product> GetAll();

        Product GetById(int id);

        void Add(Product product);

        void Update(Product product);

        void Delete(int id);
    }
}