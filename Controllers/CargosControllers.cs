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
	
	public class CargosController : Controller
	{
		CargosDataAccess objCargos = new CargosDataAccess();

		// GET: api/Cargos
		[HttpGet("[action]")]
		public IEnumerable<Cargos> ConsultarCargos()
		{
			return objCargos.ConsultarCargos();
		}

		// GET: api/Cargos/5
		[HttpGet("{id0}", Name = "BuscarCargos")]
		public Cargos BuscarCargos(System.Int32 idcargo)
		{
			return objCargos.BuscarCargos(idcargo);
		}

		// POST: api/Cargos
		[HttpPost]
		public ActionResult InsertarCargos([FromBody] Cargos data)
		{
			return objCargos.InsertarCargos(data);
		}

		// PUT: api/Cargos
		[HttpPut]
		public ActionResult ActualizarCargos([FromBody] Cargos data)
		{
			return objCargos.ActualizarCargos(data);
		}

		// DELETE: api/Cargos
		[HttpDelete]
		public ActionResult EliminarCargos([FromBody] Cargos data)
		{
			return objCargos.EliminarCargos(data);
		}
	}
}
