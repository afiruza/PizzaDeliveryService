using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDeliveryService.Models;

namespace PizzaDeliveryService.Repository
{
   public interface IPizzaRepository
    {
        void InsertPizza(Pizza pizza);
        void UpdatePizza(Pizza pizza);
        void DeletePizza(int pizzaId);
        Pizza GetPizzaById(int pizzaId);
        IEnumerable<Pizza> GetPizzas();
    }
}
