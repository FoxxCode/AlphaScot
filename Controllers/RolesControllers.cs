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
	
	public class RolesController : Controller
	{
		RolesDataAccess objRoles = new RolesDataAccess();

		// GET: api/Roles
		[HttpGet("[action]")]
		public IEnumerable<Roles> ConsultarRoles()
		{
			return objRoles.ConsultarRoles();
		}

		// GET: api/Roles/5
		[HttpGet("{id0}", Name = "BuscarRoles")]
		public Roles BuscarRoles(System.Int32 idrol)
		{
			return objRoles.BuscarRoles(idrol);
		}

		// POST: api/Roles
		[HttpPost]
		public ActionResult InsertarRoles([FromBody] Roles data)
		{
			return objRoles.InsertarRoles(data);
		}

		// PUT: api/Roles
		[HttpPut]
		public ActionResult ActualizarRoles([FromBody] Roles data)
		{
			return objRoles.ActualizarRoles(data);
		}

		// DELETE: api/Roles
		[HttpDelete]
		public ActionResult EliminarRoles([FromBody] Roles data)
		{
			return objRoles.EliminarRoles(data);
		}
	}
}
