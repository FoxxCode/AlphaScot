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
	
	public class PaisController : Controller
	{
		PaisDataAccess objPais = new PaisDataAccess();

		// GET: api/Pais
		[HttpGet("[action]")]
		public IEnumerable<Pais> ConsultarPais()
		{
			return objPais.ConsultarPais();
		}

		// GET: api/Pais/5
		[HttpGet("{id0}", Name = "BuscarPais")]
		public Pais BuscarPais(System.Int32 idpais)
		{
			return objPais.BuscarPais(idpais);
		}

		// POST: api/Pais
		[HttpPost]
		public ActionResult InsertarPais([FromBody] Pais data)
		{
			return objPais.InsertarPais(data);
		}

		// PUT: api/Pais
		[HttpPut]
		public ActionResult ActualizarPais([FromBody] Pais data)
		{
			return objPais.ActualizarPais(data);
		}

		// DELETE: api/Pais
		[HttpDelete]
		public ActionResult EliminarPais([FromBody] Pais data)
		{
			return objPais.EliminarPais(data);
		}
	}
}
