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
	
	public class ContinenteController : Controller
	{
		ContinenteDataAccess objContinente = new ContinenteDataAccess();

		// GET: api/Continente
		[HttpGet("[action]")]
		public IEnumerable<Continente> ConsultarContinente()
		{
			return objContinente.ConsultarContinente();
		}

		// GET: api/Continente/5
		[HttpGet("{id0}", Name = "BuscarContinente")]
		public Continente BuscarContinente(System.Int32 idcontinente)
		{
			return objContinente.BuscarContinente(idcontinente);
		}

		// POST: api/Continente
		[HttpPost]
		public ActionResult InsertarContinente([FromBody] Continente data)
		{
			return objContinente.InsertarContinente(data);
		}

		// PUT: api/Continente
		[HttpPut]
		public ActionResult ActualizarContinente([FromBody] Continente data)
		{
			return objContinente.ActualizarContinente(data);
		}

		// DELETE: api/Continente
		[HttpDelete]
		public ActionResult EliminarContinente([FromBody] Continente data)
		{
			return objContinente.EliminarContinente(data);
		}
	}
}
