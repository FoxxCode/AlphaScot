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
	
	public class EmpresaController : Controller
	{
		EmpresaDataAccess objEmpresa = new EmpresaDataAccess();

		// GET: api/Empresa
		[HttpGet("[action]")]
		public IEnumerable<Empresa> ConsultarEmpresa()
		{
			return objEmpresa.ConsultarEmpresa();
		}

		// GET: api/Empresa/5
		[HttpGet("{id0}", Name = "BuscarEmpresa")]
		public Empresa BuscarEmpresa(System.Int32 idempresa)
		{
			return objEmpresa.BuscarEmpresa(idempresa);
		}

		// POST: api/Empresa
		[HttpPost]
		public ActionResult InsertarEmpresa([FromBody] Empresa data)
		{
			return objEmpresa.InsertarEmpresa(data);
		}

		// PUT: api/Empresa
		[HttpPut]
		public ActionResult ActualizarEmpresa([FromBody] Empresa data)
		{
			return objEmpresa.ActualizarEmpresa(data);
		}

		// DELETE: api/Empresa
		[HttpDelete]
		public ActionResult EliminarEmpresa([FromBody] Empresa data)
		{
			return objEmpresa.EliminarEmpresa(data);
		}
	}
}
