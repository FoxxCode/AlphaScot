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
	
	public class UsuarioCuentaController : Controller
	{
		UsuarioCuentaDataAccess objUsuarioCuenta = new UsuarioCuentaDataAccess();

		// GET: api/UsuarioCuenta
		[HttpGet("[action]")]
		public IEnumerable<UsuarioCuenta> ConsultarUsuarioCuenta()
		{
			return objUsuarioCuenta.ConsultarUsuarioCuenta();
		}

		// GET: api/UsuarioCuenta/5
		[HttpGet("{id0}", Name = "BuscarUsuarioCuenta")]
		public UsuarioCuenta BuscarUsuarioCuenta(System.Int32 idusuariocuenta)
		{
			return objUsuarioCuenta.BuscarUsuarioCuenta(idusuariocuenta);
		}

		// POST: api/UsuarioCuenta
		[HttpPost]
		public ActionResult InsertarUsuarioCuenta([FromBody] UsuarioCuenta data)
		{
			return objUsuarioCuenta.InsertarUsuarioCuenta(data);
		}

		// PUT: api/UsuarioCuenta
		[HttpPut]
		public ActionResult ActualizarUsuarioCuenta([FromBody] UsuarioCuenta data)
		{
			return objUsuarioCuenta.ActualizarUsuarioCuenta(data);
		}

		// DELETE: api/UsuarioCuenta
		[HttpDelete]
		public ActionResult EliminarUsuarioCuenta([FromBody] UsuarioCuenta data)
		{
			return objUsuarioCuenta.EliminarUsuarioCuenta(data);
		}
	}
}
