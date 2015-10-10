using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Objects;
using System.Linq;

namespace EF01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SampleModel1Container())
            {
                TryGenerateSampleData(context);
                


                var q = new ObjectQuery<Project>("SELECT VALUE p FROM Projects as p WHERE p.Id > @projectId",
                    ((IObjectContextAdapter)context).ObjectContext);
                var r = q.Select("it", new ObjectParameter("projectId", 0)).ToList();

                // Create the query
                var queryString = "SELECT VALUE p FROM Projects as p WHERE p.Id > @projectId";
                var objectQuery = ((IObjectContextAdapter)context).ObjectContext.CreateQuery<Project>(queryString, new ObjectParameter("projectId", 0));

                // Get all projects satified the query
                var projects = objectQuery.ToList();

                // Select only first item
                var top1 = objectQuery.Top("1").FirstOrDefault();

                // Skip and Top, it's different than Top and Skip
                var top2 = objectQuery.Skip("it.Name DESC", "0").Top("1").ToList();

                // Get two fields
                var records = objectQuery.Select("it.Id, it.Name").Skip("it.Name", "2").Top("2");
                foreach (var record in records)
                {
                    Console.WriteLine("Id / Name: {0} / {1}", record["Id"], record["Name"]);
                }

                // 
                var results =
                    context.Projects.Where(p => p.Id > 0)
                        .Select(x => new { x.Id, x.Name })
                        .OrderByDescending(x => x.Name)
                        .Skip(2)
                        .Take(2)
                        .ToList();

                var employees = context.Employees.ToList();
            }

            Console.ReadLine();


            //EntityConnection con = new EntityConnection();


            //SampleModel1Container c = new SampleModel1Container();
            //c.Database.Connection.BeginTransaction();

            //EntityCommand ec = new EntityCommand();
            //ec.ExecuteScalarAsync();

            //SqlCommand sc = new SqlCommand();
            //sc.ExecuteReaderAsync();



            //System.Data.OleDb.OleDbCommand oc = new OleDbCommand();
            //oc.ExecuteReaderAsync();
        }

        static void TryGenerateSampleData(SampleModel1Container container)
        {
            var projects = container.Projects.ToList();

            if (projects.Count < 1)
            {
                var employee1 = new Employee()
                {
                    Id = 1
                };
                var employee2 = new Employee()
                {
                    Id = 2
                };

                container.Employees.AddOrUpdate(employee1, employee2);

                container.Projects.AddOrUpdate(new Project()
                {
                    Name = "Project 1",
                    Employee = employee1
                }, new Project()
                {
                    Name = "Project 2",
                    Employee = employee2
                }, new Project()
                {
                    Name = "Project A2",
                    Employee = employee2
                }, new Project()
                {
                    Name = "Project B2",
                    Employee = employee2
                });

                container.SaveChanges();
            }
        }
    }
}
