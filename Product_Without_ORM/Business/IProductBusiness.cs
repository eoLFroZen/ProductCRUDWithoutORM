using Product_Without_ORM.Data.Entities;
using System.Collections.Generic;

namespace Product_Without_ORM.Business
{
    public interface IProductBusiness
    {
        void Add(Product product);
        void Delete(int id);
        List<Product> GetAll();
        Product GetById(int id);
        void Update(Product product);
    }
}