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
	
	public class ServicioNumeracionController : Controller
	{
		ServicioNumeracionDataAccess objServicioNumeracion = new ServicioNumeracionDataAccess();

		// GET: api/ServicioNumeracion
		[HttpGet("[action]")]
		public IEnumerable<ServicioNumeracion> ConsultarServicioNumeracion()
		{
			return objServicioNumeracion.ConsultarServicioNumeracion();
		}

		// GET: api/ServicioNumeracion/5
		[HttpGet("{id0,id1}", Name = "BuscarServicioNumeracion")]
		public ServicioNumeracion BuscarServicioNumeracion(System.Int32 idrango,System.Int32 idservicio)
		{
			return objServicioNumeracion.BuscarServicioNumeracion(idrango,idservicio);
		}

		// POST: api/ServicioNumeracion
		[HttpPost]
		public ActionResult InsertarServicioNumeracion([FromBody] ServicioNumeracion data)
		{
			return objServicioNumeracion.InsertarServicioNumeracion(data);
		}

		// PUT: api/ServicioNumeracion
		[HttpPut]
		public ActionResult ActualizarServicioNumeracion([FromBody] ServicioNumeracion data)
		{
			return objServicioNumeracion.ActualizarServicioNumeracion(data);
		}

		// DELETE: api/ServicioNumeracion
		[HttpDelete]
		public ActionResult EliminarServicioNumeracion([FromBody] ServicioNumeracion data)
		{
			return objServicioNumeracion.EliminarServicioNumeracion(data);
		}
	}
}
