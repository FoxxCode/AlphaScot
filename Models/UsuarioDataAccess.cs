using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class UsuarioDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Usuario> ConsultarUsuario()
		{
			List<Usuario> lstUsuario = new List<Usuario>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Usuario_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Usuario _Usuario= new Usuario();
					_Usuario.idusuario = (System.String)rdr["idusuario"];
					_Usuario.idempresa = (System.Int32)rdr["idempresa"];
					_Usuario.idcomunicacion = (System.Int32)rdr["idcomunicacion"];
					_Usuario.descripcion = !rdr.IsDBNull(3) ? (System.String)rdr["descripcion"] : "";
					_Usuario.encargado = !rdr.IsDBNull(4) ? (System.Boolean)rdr["encargado"] : true;
					lstUsuario.Add(_Usuario);
				}
				Base.CerrarConexion(SqlCnn);
				return lstUsuario;
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
				return lstUsuario;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Usuario BuscarUsuario(System.String idusuario,System.Int32 idempresa)
		{
			Usuario _Usuario= new Usuario();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Usuario_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", idusuario);
				SqlCmd.Parameters.AddWithValue("@idempresa", idempresa);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Usuario.idusuario = (System.String)rdr["idusuario"];
					_Usuario.idempresa = (System.Int32)rdr["idempresa"];
					_Usuario.idcomunicacion = (System.Int32)rdr["idcomunicacion"];
					_Usuario.descripcion = !rdr.IsDBNull(3) ? (System.String)rdr["descripcion"] : "";
					_Usuario.encargado = !rdr.IsDBNull(4) ? (System.Boolean)rdr["encargado"] : true;
				}
				Base.CerrarConexion(SqlCnn);
				return _Usuario;
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
				return _Usuario;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarUsuario(Usuario _Usuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Usuario_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _Usuario.idusuario);
				SqlCmd.Parameters.AddWithValue("@idempresa", _Usuario.idempresa);
				SqlCmd.Parameters.AddWithValue("@idcomunicacion", _Usuario.idcomunicacion);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Usuario.descripcion);
				SqlCmd.Parameters.AddWithValue("@encargado", _Usuario.encargado);

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
		public ActionResult ActualizarUsuario(Usuario _Usuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Usuario_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _Usuario.idusuario);
				SqlCmd.Parameters.AddWithValue("@idempresa", _Usuario.idempresa);
				SqlCmd.Parameters.AddWithValue("@idcomunicacion", _Usuario.idcomunicacion);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Usuario.descripcion);
				SqlCmd.Parameters.AddWithValue("@encargado", _Usuario.encargado);

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
		public ActionResult EliminarUsuario(Usuario _Usuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Usuario_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _Usuario.idusuario);
				SqlCmd.Parameters.AddWithValue("@idempresa", _Usuario.idempresa);

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
