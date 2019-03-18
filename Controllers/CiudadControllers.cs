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
	
	public class CiudadController : Controller
	{
		CiudadDataAccess objCiudad = new CiudadDataAccess();

		// GET: api/Ciudad
		[HttpGet("[action]")]
		public IEnumerable<Ciudad> ConsultarCiudad()
		{
			return objCiudad.ConsultarCiudad();
		}

		// GET: api/Ciudad/5
		[HttpGet("{id0,id1}", Name = "BuscarCiudad")]
		public Ciudad BuscarCiudad(System.Int32 idciudad,System.Int32 idpais)
		{
			return objCiudad.BuscarCiudad(idciudad,idpais);
		}

		// POST: api/Ciudad
		[HttpPost]
		public ActionResult InsertarCiudad([FromBody] Ciudad data)
		{
			return objCiudad.InsertarCiudad(data);
		}

		// PUT: api/Ciudad
		[HttpPut]
		public ActionResult ActualizarCiudad([FromBody] Ciudad data)
		{
			return objCiudad.ActualizarCiudad(data);
		}

		// DELETE: api/Ciudad
		[HttpDelete]
		public ActionResult EliminarCiudad([FromBody] Ciudad data)
		{
			return objCiudad.EliminarCiudad(data);
		}
	}
}
