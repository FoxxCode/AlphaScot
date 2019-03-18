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
	
	public class ContraseniaController : Controller
	{
		ContraseniaDataAccess objContrasenia = new ContraseniaDataAccess();

		// GET: api/Contrasenia
		[HttpGet("[action]")]
		public IEnumerable<Contrasenia> ConsultarContrasenia()
		{
			return objContrasenia.ConsultarContrasenia();
		}

		// GET: api/Contrasenia/5
		[HttpGet("{id0,id1}", Name = "BuscarContrasenia")]
		public Contrasenia BuscarContrasenia(System.String idusuario,System.DateTime fecharegistro)
		{
			return objContrasenia.BuscarContrasenia(idusuario,fecharegistro);
		}

		// POST: api/Contrasenia
		[HttpPost]
		public ActionResult InsertarContrasenia([FromBody] Contrasenia data)
		{
			return objContrasenia.InsertarContrasenia(data);
		}

		// PUT: api/Contrasenia
		[HttpPut]
		public ActionResult ActualizarContrasenia([FromBody] Contrasenia data)
		{
			return objContrasenia.ActualizarContrasenia(data);
		}

		// DELETE: api/Contrasenia
		[HttpDelete]
		public ActionResult EliminarContrasenia([FromBody] Contrasenia data)
		{
			return objContrasenia.EliminarContrasenia(data);
		}
	}
}
