using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class UsuarioRolDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<UsuarioRol> ConsultarUsuarioRol()
		{
			List<UsuarioRol> lstUsuarioRol = new List<UsuarioRol>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioRol_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					UsuarioRol _UsuarioRol= new UsuarioRol();
					_UsuarioRol.idusuario = (System.String)rdr["idusuario"];
					_UsuarioRol.idrolempresa = (System.Int32)rdr["idrolempresa"];
					_UsuarioRol.idempresa = (System.Int32)rdr["idempresa"];
					_UsuarioRol.fecharegistro = !rdr.IsDBNull(4) ? (System.DateTime)rdr["fecharegistro"] : System.DateTime.Now;
					lstUsuarioRol.Add(_UsuarioRol);
				}
				Base.CerrarConexion(SqlCnn);
				return lstUsuarioRol;
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
				return lstUsuarioRol;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public UsuarioRol BuscarUsuarioRol(System.String idusuario,System.Int32 idrolempresa)
		{
			UsuarioRol _UsuarioRol= new UsuarioRol();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioRol_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", idusuario);
				SqlCmd.Parameters.AddWithValue("@idrolempresa", idrolempresa);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_UsuarioRol.idusuario = (System.String)rdr["idusuario"];
					_UsuarioRol.idrolempresa = (System.Int32)rdr["idrolempresa"];
					_UsuarioRol.idempresa = (System.Int32)rdr["idempresa"];
					_UsuarioRol.fecharegistro = !rdr.IsDBNull(4) ? (System.DateTime)rdr["fecharegistro"] : System.DateTime.Now;
				}
				Base.CerrarConexion(SqlCnn);
				return _UsuarioRol;
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
				return _UsuarioRol;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarUsuarioRol(UsuarioRol _UsuarioRol)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioRol_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _UsuarioRol.idusuario);
				SqlCmd.Parameters.AddWithValue("@idrolempresa", _UsuarioRol.idrolempresa);
				SqlCmd.Parameters.AddWithValue("@idempresa", _UsuarioRol.idempresa);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _UsuarioRol.fecharegistro);

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
		public ActionResult ActualizarUsuarioRol(UsuarioRol _UsuarioRol)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioRol_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _UsuarioRol.idusuario);
				SqlCmd.Parameters.AddWithValue("@idrolempresa", _UsuarioRol.idrolempresa);
				SqlCmd.Parameters.AddWithValue("@idempresa", _UsuarioRol.idempresa);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _UsuarioRol.fecharegistro);

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
		public ActionResult EliminarUsuarioRol(UsuarioRol _UsuarioRol)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioRol_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _UsuarioRol.idusuario);
				SqlCmd.Parameters.AddWithValue("@idrolempresa", _UsuarioRol.idrolempresa);

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
