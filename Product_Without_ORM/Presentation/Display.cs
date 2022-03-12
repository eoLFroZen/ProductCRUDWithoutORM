using Product_Without_ORM.Business;
using Product_Without_ORM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Without_ORM.Presentation
{
    public class Display
    {
        private IProductBusiness productBusiness;

        public Display(IProductBusiness productBusiness)
        {
            this.productBusiness = productBusiness;
            MainMenu();
        }

        private void MainMenu()
        {
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update new entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
            int command = int.Parse(Console.ReadLine());

            PerformCommand(command);
        }

        private void PerformCommand(int command)
        {
            switch (command)
            {
                case 1:
                    GetAllEntries();
                    GoToMainMenu();
                    break;
                case 2:
                    AddNewEntry();
                    GoToMainMenu();
                    break;
                case 3:
                    UpdateEntry();
                    GoToMainMenu();
                    break;
                case 4:
                    GetById();
                    GoToMainMenu();
                    break;
                case 5:
                    DeleteEntry();
                    GoToMainMenu();
                    break;
                case 6:
                    Console.WriteLine("Program finished!");
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    GoToMainMenu();
                    break;
            }
        }

        private void DeleteEntry()
        {
            int id = GetById();
            productBusiness.Delete(id);
        }

        private int GetById()
        {
            Console.WriteLine("Entry Id:");
            int id = int.Parse(Console.ReadLine());

            Product product = productBusiness.GetById(id);

            Console.WriteLine(product.Id);
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
            Console.WriteLine(product.Stock);
            Console.WriteLine("========================");

            return id;
        }

        private void UpdateEntry()
        {
            int id = GetById();

            Product product = new Product();
            product.Id = id;

            Console.WriteLine("Name:");
            product.Name = Console.ReadLine();
            Console.WriteLine("Price:");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Stock:");
            product.Stock = int.Parse(Console.ReadLine());

            productBusiness.Update(product);
        }

        private void AddNewEntry()
        {
            Product product = new Product();

            Console.WriteLine("Name:");
            product.Name = Console.ReadLine();
            Console.WriteLine("Price:");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Stock:");
            product.Stock = int.Parse(Console.ReadLine());

            productBusiness.Add(product);
        }

        private void GetAllEntries()
        {
            List<Product> products = this.productBusiness.GetAll();

            products.ForEach(p =>
            {
                Console.WriteLine(p.Id);
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Price);
                Console.WriteLine(p.Stock);
                Console.WriteLine("========================");
            });
        }

        private void GoToMainMenu()
        {
            Console.WriteLine("Press any key to go to Main Menu!!!");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
    }
}
