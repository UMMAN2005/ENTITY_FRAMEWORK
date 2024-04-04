using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Data;

namespace Service.Services {
    public class ProductService {
        private AppDbContext _context;

        public ProductService() {
            _context = new();
        }

        public void Add(Product product) {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product Get(int id) {
            return _context.Products.Find(id);
        }

        public List<Product> GetAll() {
            return _context.Products.ToList();
        }

        public void Update(int id, Product product) {
            Product oldProduct = _context.Products.Find(id);
            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.BrandId = product.BrandId;
            _context.SaveChanges();
        }

        public void Delete(int id) {
            Product product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
