using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Data;
using Service.Exceptions;

namespace Service.Services {
    public class BrandService {
        private AppDbContext _context;
        public BrandService() {
            _context = new();
        }

        public void Add(Brand brand) {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public Brand Get(int id) {
            return _context.Brands.Find(id);
        }

        public List<Brand> GetAll() {
            return _context.Brands.ToList();
        }

        public void Update(int id, Brand brand) {
            Brand oldBrand = _context.Brands.Find(id);
            if (GetAll().Any(b => b.Name == brand.Name)) throw new EntityDublicateException("Brand already exists");
            oldBrand.Name = brand.Name;
            _context.SaveChanges();
        }

        public void Delete(int id) {
            Brand brand = _context.Brands.Find(id);
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }
    }
}
