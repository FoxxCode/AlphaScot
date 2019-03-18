using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class UsuarioInternoDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<UsuarioInterno> ConsultarUsuarioInterno()
		{
			List<UsuarioInterno> lstUsuarioInterno = new List<UsuarioInterno>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioInterno_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					UsuarioInterno _UsuarioInterno= new UsuarioInterno();
					_UsuarioInterno.idinternousuario = (System.Int32)rdr["idinternousuario"];
					_UsuarioInterno.idinterno = (System.String)rdr["idinterno"];
					_UsuarioInterno.idcentral = (System.Int32)rdr["idcentral"];
					_UsuarioInterno.idusuario = (System.String)rdr["idusuario"];
					_UsuarioInterno.idempresa = (System.Int32)rdr["idempresa"];
					_UsuarioInterno.fecharegistro = (System.DateTime)rdr["fecharegistro"];
					lstUsuarioInterno.Add(_UsuarioInterno);
				}
				Base.CerrarConexion(SqlCnn);
				return lstUsuarioInterno;
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
				return lstUsuarioInterno;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public UsuarioInterno BuscarUsuarioInterno(System.Int32 idinternousuario)
		{
			UsuarioInterno _UsuarioInterno= new UsuarioInterno();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioInterno_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinternousuario", idinternousuario);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_UsuarioInterno.idinternousuario = (System.Int32)rdr["idinternousuario"];
					_UsuarioInterno.idinterno = (System.String)rdr["idinterno"];
					_UsuarioInterno.idcentral = (System.Int32)rdr["idcentral"];
					_UsuarioInterno.idusuario = (System.String)rdr["idusuario"];
					_UsuarioInterno.idempresa = (System.Int32)rdr["idempresa"];
					_UsuarioInterno.fecharegistro = (System.DateTime)rdr["fecharegistro"];
				}
				Base.CerrarConexion(SqlCnn);
				return _UsuarioInterno;
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
				return _UsuarioInterno;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarUsuarioInterno(UsuarioInterno _UsuarioInterno)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioInterno_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDInternoUsuario = new SqlParameter();
				pIDInternoUsuario.ParameterName = "@IDInternoUsuario";
				pIDInternoUsuario.Value = 0;
				SqlCmd.Parameters.Add(pIDInternoUsuario);
				pIDInternoUsuario.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idinterno", _UsuarioInterno.idinterno);
				SqlCmd.Parameters.AddWithValue("@idcentral", _UsuarioInterno.idcentral);
				SqlCmd.Parameters.AddWithValue("@idusuario", _UsuarioInterno.idusuario);
				SqlCmd.Parameters.AddWithValue("@idempresa", _UsuarioInterno.idempresa);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _UsuarioInterno.fecharegistro);

				SqlCmd.ExecuteNonQuery();
				_UsuarioInterno.idinternousuario = (System.Int32)pIDInternoUsuario.Value;
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
		public ActionResult ActualizarUsuarioInterno(UsuarioInterno _UsuarioInterno)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioInterno_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinternousuario", _UsuarioInterno.idinternousuario);
				SqlCmd.Parameters.AddWithValue("@idinterno", _UsuarioInterno.idinterno);
				SqlCmd.Parameters.AddWithValue("@idcentral", _UsuarioInterno.idcentral);
				SqlCmd.Parameters.AddWithValue("@idusuario", _UsuarioInterno.idusuario);
				SqlCmd.Parameters.AddWithValue("@idempresa", _UsuarioInterno.idempresa);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _UsuarioInterno.fecharegistro);

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
		public ActionResult EliminarUsuarioInterno(UsuarioInterno _UsuarioInterno)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioInterno_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinternousuario", _UsuarioInterno.idinternousuario);

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
