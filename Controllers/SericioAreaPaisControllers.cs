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
	
	public class SericioAreaPaisController : Controller
	{
		SericioAreaPaisDataAccess objSericioAreaPais = new SericioAreaPaisDataAccess();

		// GET: api/SericioAreaPais
		[HttpGet("[action]")]
		public IEnumerable<SericioAreaPais> ConsultarSericioAreaPais()
		{
			return objSericioAreaPais.ConsultarSericioAreaPais();
		}

		// GET: api/SericioAreaPais/5
		[HttpGet("{id0,id1}", Name = "BuscarSericioAreaPais")]
		public SericioAreaPais BuscarSericioAreaPais(System.Int32 idareapais,System.Int32 idservicio)
		{
			return objSericioAreaPais.BuscarSericioAreaPais(idareapais,idservicio);
		}

		// POST: api/SericioAreaPais
		[HttpPost]
		public ActionResult InsertarSericioAreaPais([FromBody] SericioAreaPais data)
		{
			return objSericioAreaPais.InsertarSericioAreaPais(data);
		}

		// PUT: api/SericioAreaPais
		[HttpPut]
		public ActionResult ActualizarSericioAreaPais([FromBody] SericioAreaPais data)
		{
			return objSericioAreaPais.ActualizarSericioAreaPais(data);
		}

		// DELETE: api/SericioAreaPais
		[HttpDelete]
		public ActionResult EliminarSericioAreaPais([FromBody] SericioAreaPais data)
		{
			return objSericioAreaPais.EliminarSericioAreaPais(data);
		}
	}
}
