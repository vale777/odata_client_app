using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    class Program
    {

        //get an entire entity set
        static void ListAllProducts(Default.Container container)
        {
            foreach (var p in container.Products)
            {
                Console.WriteLine("{0} {1} {2}", p.Name, p.Id, p.Category);
            }
        }

        static void AppProduct(Default.Container container, ProductService.Models.Product product)
        {
            container.AddToProducts(product);
            var serviceResponse = container.SaveChanges();
            foreach (var operationsResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationsResponse.StatusCode);
            }
        }

        static void Main(string[] args)
        {
            //local URI
            string serviceUri = "http://localhost:52605/";
            var container = new Default.Container(new Uri(serviceUri));

            var product = new ProductService.Models.Product()
            {
                Name = "Holzplatte",
                Category = "Holz"
            };

            //AddProduct(container, product);
            ListAllProducts(container);
        }
    }
}
