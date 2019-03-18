using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class CiudadDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Ciudad> ConsultarCiudad()
		{
			List<Ciudad> lstCiudad = new List<Ciudad>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudad_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Ciudad _Ciudad= new Ciudad();
					_Ciudad.idciudad = (System.Int32)rdr["idciudad"];
					_Ciudad.idpais = (System.Int32)rdr["idpais"];
					_Ciudad.descripcion = !rdr.IsDBNull(2) ? (System.String)rdr["descripcion"] : "";
					lstCiudad.Add(_Ciudad);
				}
				Base.CerrarConexion(SqlCnn);
				return lstCiudad;
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
				return lstCiudad;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Ciudad BuscarCiudad(System.Int32 idciudad,System.Int32 idpais)
		{
			Ciudad _Ciudad= new Ciudad();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudad_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idciudad", idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", idpais);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Ciudad.idciudad = (System.Int32)rdr["idciudad"];
					_Ciudad.idpais = (System.Int32)rdr["idpais"];
					_Ciudad.descripcion = !rdr.IsDBNull(2) ? (System.String)rdr["descripcion"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _Ciudad;
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
				return _Ciudad;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarCiudad(Ciudad _Ciudad)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudad_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idciudad", _Ciudad.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _Ciudad.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Ciudad.descripcion);

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
		public ActionResult ActualizarCiudad(Ciudad _Ciudad)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudad_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idciudad", _Ciudad.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _Ciudad.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Ciudad.descripcion);

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
		public ActionResult EliminarCiudad(Ciudad _Ciudad)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudad_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idciudad", _Ciudad.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _Ciudad.idpais);

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
