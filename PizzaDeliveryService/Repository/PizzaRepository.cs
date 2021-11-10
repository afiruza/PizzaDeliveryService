using PizzaDeliveryService.DbContexts;
using PizzaDeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDeliveryService.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaContext _dbContext;

        public PizzaRepository(PizzaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeletePizza(int pizzaId)
        {
            var pizza = _dbContext.Pizzas.Find(pizzaId);
            _dbContext.Pizzas.Remove(pizza);
            Save();
        }

        public Pizza GetPizzaById(int pizzaId)
        {
            var pizza = _dbContext.Pizzas.Find(pizzaId);
            return pizza;
        }

        public IEnumerable<Pizza> GetPizzas()
        {
            return _dbContext.Pizzas.ToList();
        }

        public void InsertPizza(Pizza pizza)
        {
            _dbContext.Add(pizza);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdatePizza(Pizza pizza)
        {
            _dbContext.Entry(pizza).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
