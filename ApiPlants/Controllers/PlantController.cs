using Microsoft.AspNetCore.Mvc;
using ApiPlants.Data;
using ApiPlants.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiPlants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly PlantDbContext context;
        public PlantController(PlantDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Plant>>Get()
        {
            return context.Plants.ToList();
        }
        
        [HttpGet("{id}", Name = "ObtenerPlanta")]
        public ActionResult<Plant>Get(int id)
        {
            var plant = context.Plants.FirstOrDefault(x => x.Id == id);
            if(plant == null)
            {
                return NotFound();
            }
            return plant;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Plant plant)
        {
            context.Plants.Add(plant);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerPlanta", new { id = plant.Id }, plant);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Plant plant, int id)
        {
            if(id != plant.Id)
            {
                return BadRequest();
            }

            context.Entry(plant).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Plant> Delete(int id)
        {
            var plant = context.Plants.FirstOrDefault(x => x.Id == id);
            if(plant == null)
            {
                return NotFound();
            }

            context.Entry(plant).State = EntityState.Deleted;
            context.SaveChanges();
            return plant;
        }

    }
}
