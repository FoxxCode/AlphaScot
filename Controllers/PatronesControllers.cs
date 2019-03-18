using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace proyecto.Models
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	
	public class PatronesController : Controller
	{
		PatronesDataAccess objPatrones = new PatronesDataAccess();

		// GET: api/Patrones
		[HttpGet("[action]")]
		public IEnumerable<Patrones> ConsultarPatrones()
		{
			return objPatrones.ConsultarPatrones();
		}

		// GET: api/Patrones/5
		[HttpGet("{id0}", Name = "BuscarPatrones")]
		public Patrones BuscarPatrones(System.String idpatron)
		{
			return objPatrones.BuscarPatrones(idpatron);
		}

		// POST: api/Patrones
		[HttpPost]
		public ActionResult InsertarPatrones([FromBody] Patrones data)
		{
			return objPatrones.InsertarPatrones(data);
		}

		// PUT: api/Patrones
		[HttpPut]
		public ActionResult ActualizarPatrones([FromBody] Patrones data)
		{
			return objPatrones.ActualizarPatrones(data);
		}

		// DELETE: api/Patrones
		[HttpDelete]
		public ActionResult EliminarPatrones([FromBody] Patrones data)
		{
			return objPatrones.EliminarPatrones(data);
		}
	}
}
