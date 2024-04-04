using ConsoleApp42.DAL;
using ConsoleApp42.Models;
using System;
using System.Linq;
using System.Reflection.Emit;

using AppDbContext db = new();
db.Database.EnsureCreated();

string choice;
do {
    ShowMenu();
    Console.Write("Please choose an operation: ");
    choice = Console.ReadLine();
    switch(choice) {

        case "1":
            Console.Write("Enter brand name: ");
            string brandName = Console.ReadLine();
            Console.Write("Enter total value: ");
            double totalValue = double.Parse(Console.ReadLine());
            db.Brands.Add(new Brand { Name = brandName, TotalValue = totalValue });
            db.SaveChanges();
            break;
        case "2":
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter brand id: ");
            int brandId = int.Parse(Console.ReadLine());
            try {
                db.Products.Add(new Product { Name = productName, Price = price, BrandId = brandId });
                db.SaveChanges();
            } catch {
                Console.WriteLine("An error occured!");
            }
            break;
        case "3":
            Console.Write("Enter brand id: ");
            brandId = int.Parse(Console.ReadLine());
            Brand brand = db.Brands.Find(brandId);
            if (brand != null) {
                Console.WriteLine($"Brand: {brand.Name}, Total Value: {brand.TotalValue}");
            } else {
                Console.WriteLine("Brand not found");
            }
            break;
        case "4":
            Console.Write("Enter product id: ");
            int productId = int.Parse(Console.ReadLine());
            Product product = db.Products.Find(productId);
            if (product != null) {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Brand Id: {product.BrandId}");
            } else {
                Console.WriteLine("Product not found");
            }
            break;
        case "5":
            var brands = db.Brands.ToList();
            foreach (var b in brands) {
                Console.WriteLine($"Id: {b.Id}, Brand: {b.Name}, Total Value: {b.TotalValue}");
            }
            break;
        case "6":
            var products = db.Products.ToList();
            foreach (var p in products) {
                Console.WriteLine($"Id: {p.Id}, Product: {p.Name}, Price: {p.Price}, Brand Id: {p.BrandId}");
            }
            break;
        case "7":
            Console.Write("Enter brand id: ");
            brandId = int.Parse(Console.ReadLine());
            brand = db.Brands.Find(brandId);
            if (brand != null) {
                db.Brands.Remove(brand);
                db.SaveChanges();
            } else {
                Console.WriteLine("Brand not found");
            }
            break;
        case "8":
            Console.Write("Enter product id: ");
            productId = int.Parse(Console.ReadLine());
            product = db.Products.Find(productId);
            if (product != null) {
                db.Products.Remove(product);
                db.SaveChanges();
            } else {
                Console.WriteLine("Product not found");
            }
            break;
        case "9":
            Console.Write("Enter brand id: ");
            brandId = int.Parse(Console.ReadLine());
            brand = db.Brands.Find(brandId);
            if (brand != null) {
                Console.Write("Enter new brand name: ");
                brandName = Console.ReadLine();
                Console.Write("Enter new total value: ");
                totalValue = double.Parse(Console.ReadLine());
                brand.Name = brandName;
                brand.TotalValue = totalValue;
                db.SaveChanges();
            } else {
                Console.WriteLine("Brand not found");
            }
            break;
        case "10":
            Console.Write("Enter product id: ");
            productId = int.Parse(Console.ReadLine());
            product = db.Products.Find(productId);
            if (product != null) {
                Console.Write("Enter new product name: ");
                productName = Console.ReadLine();
                Console.Write("Enter new price: ");
                price = double.Parse(Console.ReadLine());
                Console.Write("Enter new brand id: ");
                brandId = int.Parse(Console.ReadLine());
                product.Name = productName;
                product.Price = price;
                product.BrandId = brandId;
                db.SaveChanges();
            } else {
                Console.WriteLine("Product not found");
            }
            break;
        case "0":
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

} while (choice != "0");



static void ShowMenu() {
    Console.WriteLine("1. Add Brand");
    Console.WriteLine("2. Add Product");
    Console.WriteLine("3. Get Brand By Id");
    Console.WriteLine("4. Get Product By Id");
    Console.WriteLine("5. Get Brands");
    Console.WriteLine("6. Get Products");
    Console.WriteLine("7. Delete Brand");
    Console.WriteLine("8. Delete Product");
    Console.WriteLine("9. Update Brand");
    Console.WriteLine("10.Update Product");
    Console.WriteLine("0. Exit");
}