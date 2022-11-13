using Microsoft.EntityFrameworkCore;
using Ntmng.Model.Models;

namespace Ntmng.DataService;

public static class InitData
{
    public static void Init(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                UserName = "admin",
                FirstName = "Kamil",
                LastName = "Wojcieszek",
                Email = "kwojcieszek@gmail.com",
                MobilePhone = "602174021",
                Password = "HiP+DbplZA8yEB+dW3tQDw9yoGPtzZymRY8u94L8BOE=",
                DateAdded = DateTime.Now
            });
    }

    public static void SampleData()
    {
        var db = new Database();

        for (int i = 1; i < 10000; i++)
        {
            //var product = new Product() { Code = $"Code{i}", Name = $"name{i}", Index = $"Index{i}", DateAdded = DateTime.Now };
            //db.Products.Add(product);
        }

        db.SaveChanges();
    }
}