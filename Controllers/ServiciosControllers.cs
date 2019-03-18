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
	
	public class ServiciosController : Controller
	{
		ServiciosDataAccess objServicios = new ServiciosDataAccess();

		// GET: api/Servicios
		[HttpGet("[action]")]
		public IEnumerable<Servicios> ConsultarServicios()
		{
			return objServicios.ConsultarServicios();
		}

		// GET: api/Servicios/5
		[HttpGet("{id0}", Name = "BuscarServicios")]
		public Servicios BuscarServicios(System.Int32 idservicio)
		{
			return objServicios.BuscarServicios(idservicio);
		}

		// POST: api/Servicios
		[HttpPost]
		public ActionResult InsertarServicios([FromBody] Servicios data)
		{
			return objServicios.InsertarServicios(data);
		}

		// PUT: api/Servicios
		[HttpPut]
		public ActionResult ActualizarServicios([FromBody] Servicios data)
		{
			return objServicios.ActualizarServicios(data);
		}

		// DELETE: api/Servicios
		[HttpDelete]
		public ActionResult EliminarServicios([FromBody] Servicios data)
		{
			return objServicios.EliminarServicios(data);
		}
	}
}
