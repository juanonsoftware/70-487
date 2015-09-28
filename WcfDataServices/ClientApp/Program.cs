using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.DataServices;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new TestingModelContainer(new Uri("http://localhost:63087/CategoryService.svc"));


            container.BuildingRequest += container_BuildingRequest;

            var categories = container.Categories.Where(x => x.Id >= 1).ToList();

            Console.WriteLine("Existing categories");
            foreach (var category in categories)
            {
                Console.WriteLine("{0}: {1}", category.Id, category.Name);
            }

            Console.WriteLine("Add new category");
            container.AddToCategories(new Category()
            {
                Name = "Category " + DateTime.Now
            });

            if (categories.Any())
            {
                Console.WriteLine("Delete a category");
                container.DeleteObject(categories.First());
            }

            var savingResult = container.SaveChanges(SaveChangesOptions.Batch);
            Console.WriteLine(savingResult.BatchStatusCode);

            Console.ReadLine();
        }
    }
}
