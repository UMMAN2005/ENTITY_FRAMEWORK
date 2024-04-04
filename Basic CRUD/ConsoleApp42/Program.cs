using ConsoleApp42.DAL;
using ConsoleApp42.Models;
using System;
using System.Linq;

using (AppDbContext db = new()) {
    // Create
    db.Add(new Brand("Samsung"));
    db.Add(new Brand("Apple"));
    db.Add(new Brand("Huawei"));
    db.SaveChanges();

    // Read
    Console.WriteLine("Before:");
    foreach (var brand in db.Brands.ToList()) {
        Console.WriteLine(brand);
    }

    // Update
    var brandToUpdate = db.Brands.First(b => b.Id == 1);
    if (brandToUpdate != null) {
        brandToUpdate.Name = "Samsung Electronics";
        db.SaveChanges();
    }

    // Delete
    var brandsToRemove = db.Brands.Where(b => b.Id >= 4 && b.Id <= 6).ToList();
    db.Brands.RemoveRange(brandsToRemove);
    db.SaveChanges();

    // Read
    Console.WriteLine("\nAfter:");
    foreach (var brand in db.Brands.ToList()) {
        Console.WriteLine(brand);
    }
}
