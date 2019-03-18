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
	
	public class ComunicacionEmpresaController : Controller
	{
		ComunicacionEmpresaDataAccess objComunicacionEmpresa = new ComunicacionEmpresaDataAccess();

		// GET: api/ComunicacionEmpresa
		[HttpGet("[action]")]
		public IEnumerable<ComunicacionEmpresa> ConsultarComunicacionEmpresa()
		{
			return objComunicacionEmpresa.ConsultarComunicacionEmpresa();
		}

		// GET: api/ComunicacionEmpresa/5
		[HttpGet("{id0,id1}", Name = "BuscarComunicacionEmpresa")]
		public ComunicacionEmpresa BuscarComunicacionEmpresa(System.Int32 idcomunicacion,System.Int32 idempresa)
		{
			return objComunicacionEmpresa.BuscarComunicacionEmpresa(idcomunicacion,idempresa);
		}

		// POST: api/ComunicacionEmpresa
		[HttpPost]
		public ActionResult InsertarComunicacionEmpresa([FromBody] ComunicacionEmpresa data)
		{
			return objComunicacionEmpresa.InsertarComunicacionEmpresa(data);
		}

		// PUT: api/ComunicacionEmpresa
		[HttpPut]
		public ActionResult ActualizarComunicacionEmpresa([FromBody] ComunicacionEmpresa data)
		{
			return objComunicacionEmpresa.ActualizarComunicacionEmpresa(data);
		}

		// DELETE: api/ComunicacionEmpresa
		[HttpDelete]
		public ActionResult EliminarComunicacionEmpresa([FromBody] ComunicacionEmpresa data)
		{
			return objComunicacionEmpresa.EliminarComunicacionEmpresa(data);
		}
	}
}
