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
	
	public class RolEmpresaController : Controller
	{
		RolEmpresaDataAccess objRolEmpresa = new RolEmpresaDataAccess();

		// GET: api/RolEmpresa
		[HttpGet("[action]")]
		public IEnumerable<RolEmpresa> ConsultarRolEmpresa()
		{
			return objRolEmpresa.ConsultarRolEmpresa();
		}

		// GET: api/RolEmpresa/5
		[HttpGet("{id0}", Name = "BuscarRolEmpresa")]
		public RolEmpresa BuscarRolEmpresa(System.Int32 idrolempresa)
		{
			return objRolEmpresa.BuscarRolEmpresa(idrolempresa);
		}

		// POST: api/RolEmpresa
		[HttpPost]
		public ActionResult InsertarRolEmpresa([FromBody] RolEmpresa data)
		{
			return objRolEmpresa.InsertarRolEmpresa(data);
		}

		// PUT: api/RolEmpresa
		[HttpPut]
		public ActionResult ActualizarRolEmpresa([FromBody] RolEmpresa data)
		{
			return objRolEmpresa.ActualizarRolEmpresa(data);
		}

		// DELETE: api/RolEmpresa
		[HttpDelete]
		public ActionResult EliminarRolEmpresa([FromBody] RolEmpresa data)
		{
			return objRolEmpresa.EliminarRolEmpresa(data);
		}
	}
}
