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
	
	public class DepartamentoController : Controller
	{
		DepartamentoDataAccess objDepartamento = new DepartamentoDataAccess();

		// GET: api/Departamento
		[HttpGet("[action]")]
		public IEnumerable<Departamento> ConsultarDepartamento()
		{
			return objDepartamento.ConsultarDepartamento();
		}

		// GET: api/Departamento/5
		[HttpGet("{id0,id1}", Name = "BuscarDepartamento")]
		public Departamento BuscarDepartamento(System.String iddepartamento,System.Int32 idempresa)
		{
			return objDepartamento.BuscarDepartamento(iddepartamento,idempresa);
		}

		// POST: api/Departamento
		[HttpPost]
		public ActionResult InsertarDepartamento([FromBody] Departamento data)
		{
			return objDepartamento.InsertarDepartamento(data);
		}

		// PUT: api/Departamento
		[HttpPut]
		public ActionResult ActualizarDepartamento([FromBody] Departamento data)
		{
			return objDepartamento.ActualizarDepartamento(data);
		}

		// DELETE: api/Departamento
		[HttpDelete]
		public ActionResult EliminarDepartamento([FromBody] Departamento data)
		{
			return objDepartamento.EliminarDepartamento(data);
		}
	}
}
