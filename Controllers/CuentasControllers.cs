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
	
	public class CuentasController : Controller
	{
		CuentasDataAccess objCuentas = new CuentasDataAccess();

		// GET: api/Cuentas
		[HttpGet("[action]")]
		public IEnumerable<Cuentas> ConsultarCuentas()
		{
			return objCuentas.ConsultarCuentas();
		}

		// GET: api/Cuentas/5
		[HttpGet("{id0,id1}", Name = "BuscarCuentas")]
		public Cuentas BuscarCuentas(System.String idcuenta,System.Int32 idcentral)
		{
			return objCuentas.BuscarCuentas(idcuenta,idcentral);
		}

		// POST: api/Cuentas
		[HttpPost]
		public ActionResult InsertarCuentas([FromBody] Cuentas data)
		{
			return objCuentas.InsertarCuentas(data);
		}

		// PUT: api/Cuentas
		[HttpPut]
		public ActionResult ActualizarCuentas([FromBody] Cuentas data)
		{
			return objCuentas.ActualizarCuentas(data);
		}

		// DELETE: api/Cuentas
		[HttpDelete]
		public ActionResult EliminarCuentas([FromBody] Cuentas data)
		{
			return objCuentas.EliminarCuentas(data);
		}
	}
}
