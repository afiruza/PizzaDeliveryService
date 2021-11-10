using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryService.Models;
using PizzaDeliveryService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaDeliveryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        // GET: api/<PizzaController>
        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            var pizzas = _pizzaRepository.GetPizzas();
            return pizzas;
          
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public IActionResult  Get(int id)
        {
            var pizza = _pizzaRepository.GetPizzaById(id);
            return new OkObjectResult(pizza);

          
        }

        // POST api/<PizzaController>
        [HttpPost]
        public IActionResult Post([FromBody]  Pizza pizza)
        {
            using(var scope = new TransactionScope())
            {
                _pizzaRepository.InsertPizza(pizza);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
            }
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pizza pizza)
        {
            if(pizza != null)
            {
                using (var scope = new TransactionScope())
                {
                    _pizzaRepository.UpdatePizza(pizza);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pizzaRepository.DeletePizza(id);
            return new OkResult();
        }
    }
}
