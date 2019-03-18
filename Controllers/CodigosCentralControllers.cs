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
	
	public class CodigosCentralController : Controller
	{
		CodigosCentralDataAccess objCodigosCentral = new CodigosCentralDataAccess();

		// GET: api/CodigosCentral
		[HttpGet("[action]")]
		public IEnumerable<CodigosCentral> ConsultarCodigosCentral()
		{
			return objCodigosCentral.ConsultarCodigosCentral();
		}

		// GET: api/CodigosCentral/5
		[HttpGet("{id0,id1,id2,id3}", Name = "BuscarCodigosCentral")]
		public CodigosCentral BuscarCodigosCentral(System.String idcodigo,System.DateTime fecha,System.String idcuenta,System.Int32 idcentral)
		{
			return objCodigosCentral.BuscarCodigosCentral(idcodigo,fecha,idcuenta,idcentral);
		}

		// POST: api/CodigosCentral
		[HttpPost]
		public ActionResult InsertarCodigosCentral([FromBody] CodigosCentral data)
		{
			return objCodigosCentral.InsertarCodigosCentral(data);
		}

		// PUT: api/CodigosCentral
		[HttpPut]
		public ActionResult ActualizarCodigosCentral([FromBody] CodigosCentral data)
		{
			return objCodigosCentral.ActualizarCodigosCentral(data);
		}

		// DELETE: api/CodigosCentral
		[HttpDelete]
		public ActionResult EliminarCodigosCentral([FromBody] CodigosCentral data)
		{
			return objCodigosCentral.EliminarCodigosCentral(data);
		}
	}
}
