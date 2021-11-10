using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaDeliveryService.Models;

namespace PizzaDeliveryService.DbContexts
{
    public class PizzaContext:DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options ): base(options) 
        { }
        public DbSet<Pizza> Pizzas { get; set; }

    }
}
