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
	
	public class DireccionEmpresaController : Controller
	{
		DireccionEmpresaDataAccess objDireccionEmpresa = new DireccionEmpresaDataAccess();

		// GET: api/DireccionEmpresa
		[HttpGet("[action]")]
		public IEnumerable<DireccionEmpresa> ConsultarDireccionEmpresa()
		{
			return objDireccionEmpresa.ConsultarDireccionEmpresa();
		}

		// GET: api/DireccionEmpresa/5
		[HttpGet("{id0,id1}", Name = "BuscarDireccionEmpresa")]
		public DireccionEmpresa BuscarDireccionEmpresa(System.Int32 iddireccion,System.Int32 idempresa)
		{
			return objDireccionEmpresa.BuscarDireccionEmpresa(iddireccion,idempresa);
		}

		// POST: api/DireccionEmpresa
		[HttpPost]
		public ActionResult InsertarDireccionEmpresa([FromBody] DireccionEmpresa data)
		{
			return objDireccionEmpresa.InsertarDireccionEmpresa(data);
		}

		// PUT: api/DireccionEmpresa
		[HttpPut]
		public ActionResult ActualizarDireccionEmpresa([FromBody] DireccionEmpresa data)
		{
			return objDireccionEmpresa.ActualizarDireccionEmpresa(data);
		}

		// DELETE: api/DireccionEmpresa
		[HttpDelete]
		public ActionResult EliminarDireccionEmpresa([FromBody] DireccionEmpresa data)
		{
			return objDireccionEmpresa.EliminarDireccionEmpresa(data);
		}
	}
}
