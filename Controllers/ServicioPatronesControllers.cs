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
	
	public class ServicioPatronesController : Controller
	{
		ServicioPatronesDataAccess objServicioPatrones = new ServicioPatronesDataAccess();

		// GET: api/ServicioPatrones
		[HttpGet("[action]")]
		public IEnumerable<ServicioPatrones> ConsultarServicioPatrones()
		{
			return objServicioPatrones.ConsultarServicioPatrones();
		}

		// GET: api/ServicioPatrones/5
		[HttpGet("{id0}", Name = "BuscarServicioPatrones")]
		public ServicioPatrones BuscarServicioPatrones(System.String idpatron)
		{
			return objServicioPatrones.BuscarServicioPatrones(idpatron);
		}

		// POST: api/ServicioPatrones
		[HttpPost]
		public ActionResult InsertarServicioPatrones([FromBody] ServicioPatrones data)
		{
			return objServicioPatrones.InsertarServicioPatrones(data);
		}

		// PUT: api/ServicioPatrones
		[HttpPut]
		public ActionResult ActualizarServicioPatrones([FromBody] ServicioPatrones data)
		{
			return objServicioPatrones.ActualizarServicioPatrones(data);
		}

		// DELETE: api/ServicioPatrones
		[HttpDelete]
		public ActionResult EliminarServicioPatrones([FromBody] ServicioPatrones data)
		{
			return objServicioPatrones.EliminarServicioPatrones(data);
		}
	}
}
