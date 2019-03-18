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
	
	public class NumeracionController : Controller
	{
		NumeracionDataAccess objNumeracion = new NumeracionDataAccess();

		// GET: api/Numeracion
		[HttpGet("[action]")]
		public IEnumerable<Numeracion> ConsultarNumeracion()
		{
			return objNumeracion.ConsultarNumeracion();
		}

		// GET: api/Numeracion/5
		[HttpGet("{id0}", Name = "BuscarNumeracion")]
		public Numeracion BuscarNumeracion(System.Int32 idrango)
		{
			return objNumeracion.BuscarNumeracion(idrango);
		}

		// POST: api/Numeracion
		[HttpPost]
		public ActionResult InsertarNumeracion([FromBody] Numeracion data)
		{
			return objNumeracion.InsertarNumeracion(data);
		}

		// PUT: api/Numeracion
		[HttpPut]
		public ActionResult ActualizarNumeracion([FromBody] Numeracion data)
		{
			return objNumeracion.ActualizarNumeracion(data);
		}

		// DELETE: api/Numeracion
		[HttpDelete]
		public ActionResult EliminarNumeracion([FromBody] Numeracion data)
		{
			return objNumeracion.EliminarNumeracion(data);
		}
	}
}
