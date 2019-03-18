using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class ContraseniaDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Contrasenia> ConsultarContrasenia()
		{
			List<Contrasenia> lstContrasenia = new List<Contrasenia>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Contrasenia_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Contrasenia _Contrasenia= new Contrasenia();
					_Contrasenia.idusuario = (System.String)rdr["idusuario"];
					_Contrasenia.fecharegistro = (System.DateTime)rdr["fecharegistro"];
					_Contrasenia.clave = !rdr.IsDBNull(2) ? (System.String)rdr["clave"] : "";
					lstContrasenia.Add(_Contrasenia);
				}
				Base.CerrarConexion(SqlCnn);
				return lstContrasenia;
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
				return lstContrasenia;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Contrasenia BuscarContrasenia(System.String idusuario,System.DateTime fecharegistro)
		{
			Contrasenia _Contrasenia= new Contrasenia();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Contrasenia_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", idusuario);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", fecharegistro);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Contrasenia.idusuario = (System.String)rdr["idusuario"];
					_Contrasenia.fecharegistro = (System.DateTime)rdr["fecharegistro"];
					_Contrasenia.clave = !rdr.IsDBNull(2) ? (System.String)rdr["clave"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _Contrasenia;
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
				return _Contrasenia;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarContrasenia(Contrasenia _Contrasenia)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Contrasenia_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _Contrasenia.idusuario);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _Contrasenia.fecharegistro);
				SqlCmd.Parameters.AddWithValue("@clave", _Contrasenia.clave);

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
		public ActionResult ActualizarContrasenia(Contrasenia _Contrasenia)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Contrasenia_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _Contrasenia.idusuario);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _Contrasenia.fecharegistro);
				SqlCmd.Parameters.AddWithValue("@clave", _Contrasenia.clave);

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
		public ActionResult EliminarContrasenia(Contrasenia _Contrasenia)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Contrasenia_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _Contrasenia.idusuario);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _Contrasenia.fecharegistro);

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
