using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Data;

namespace Service.Services {
    public class OrderService {

        private AppDbContext _context;
        public OrderService() { 
            _context = new();
        }

        public void Add(Order order) {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order Get(int id) {
            return _context.Orders.Find(id);
        }

        public void Update(Order order) {
            Order oldOrder = _context.Orders.Find(order.Id);
            oldOrder.ProductId = order.ProductId;
            oldOrder.Count = order.Count;
            _context.SaveChanges();
        }

        public void Delete(int id) {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public List<Order> GetAll() {
            return _context.Orders.ToList();
        }

    }
}
