using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class DepartamentoDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Departamento> ConsultarDepartamento()
		{
			List<Departamento> lstDepartamento = new List<Departamento>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Departamento_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Departamento _Departamento= new Departamento();
					_Departamento.iddepartamento = (System.String)rdr["iddepartamento"];
					_Departamento.idempresa = (System.Int32)rdr["idempresa"];
					_Departamento.descripcion = (System.String)rdr["descripcion"];
					_Departamento.nivel = !rdr.IsDBNull(3) ? (System.Int32)rdr["nivel"] : (System.Int32)0;
					_Departamento.deptopadre = !rdr.IsDBNull(4) ? (System.String)rdr["deptopadre"] : "";
					lstDepartamento.Add(_Departamento);
				}
				Base.CerrarConexion(SqlCnn);
				return lstDepartamento;
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						throw new Exception(se.Message);
					else
						throw new Exception("Error en Operacion de Consulta de Datos");
				}
				return lstDepartamento;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Departamento BuscarDepartamento(System.String iddepartamento,System.Int32 idempresa)
		{
			Departamento _Departamento= new Departamento();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Departamento_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddepartamento", iddepartamento);
				SqlCmd.Parameters.AddWithValue("@idempresa", idempresa);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Departamento.iddepartamento = (System.String)rdr["iddepartamento"];
					_Departamento.idempresa = (System.Int32)rdr["idempresa"];
					_Departamento.descripcion = (System.String)rdr["descripcion"];
					_Departamento.nivel = !rdr.IsDBNull(3) ? (System.Int32)rdr["nivel"] : (System.Int32)0;
					_Departamento.deptopadre = !rdr.IsDBNull(4) ? (System.String)rdr["deptopadre"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _Departamento;
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						throw new Exception(se.Message);
					else
						throw new Exception("Error en Operacion en Busqueda de Datos");
				}
				return _Departamento;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarDepartamento(Departamento _Departamento)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Departamento_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddepartamento", _Departamento.iddepartamento);
				SqlCmd.Parameters.AddWithValue("@idempresa", _Departamento.idempresa);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Departamento.descripcion);
				SqlCmd.Parameters.AddWithValue("@nivel", _Departamento.nivel);
				SqlCmd.Parameters.AddWithValue("@deptopadre", _Departamento.deptopadre);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				return Ok("Operacion realizada correctamente");
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						return BadRequest(se.Message);
					else
						return BadRequest("Error en Operacion de Insercion de Datos");
				}
			}
			catch (Exception Ex)
			{
				return BadRequest(Ex.Message);
			}
			return Ok("");
		}
		public ActionResult ActualizarDepartamento(Departamento _Departamento)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Departamento_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddepartamento", _Departamento.iddepartamento);
				SqlCmd.Parameters.AddWithValue("@idempresa", _Departamento.idempresa);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Departamento.descripcion);
				SqlCmd.Parameters.AddWithValue("@nivel", _Departamento.nivel);
				SqlCmd.Parameters.AddWithValue("@deptopadre", _Departamento.deptopadre);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				return Ok("Operacion realizada correctamente");
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						return BadRequest(se.Message);
					else
						return BadRequest("Error en Operacion de Actualizacion de Datos");
				}
			}
			catch (Exception Ex)
			{
				return BadRequest(Ex.Message);
			}
			return Ok("");
		}
		public ActionResult EliminarDepartamento(Departamento _Departamento)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Departamento_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddepartamento", _Departamento.iddepartamento);
				SqlCmd.Parameters.AddWithValue("@idempresa", _Departamento.idempresa);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				return Ok("Operacion realizada correctamente");
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						return BadRequest(se.Message);
					else
						return BadRequest("Error en Operacion de Eliminacion de Datos");
				}
			}
			catch (Exception Ex)
			{
				return BadRequest(Ex.Message);
			}
			return Ok("");
		}
	}
}
