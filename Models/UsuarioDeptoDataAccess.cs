using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class UsuarioDeptoDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<UsuarioDepto> ConsultarUsuarioDepto()
		{
			List<UsuarioDepto> lstUsuarioDepto = new List<UsuarioDepto>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioDepto_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					UsuarioDepto _UsuarioDepto= new UsuarioDepto();
					_UsuarioDepto.idusuariodepto = (System.Int32)rdr["idusuariodepto"];
					_UsuarioDepto.iddepartamento = (System.String)rdr["iddepartamento"];
					_UsuarioDepto.idcargo = (System.Int32)rdr["idcargo"];
					_UsuarioDepto.idempresa = (System.Int32)rdr["idempresa"];
					_UsuarioDepto.idusuario = (System.String)rdr["idusuario"];
					_UsuarioDepto.fecharegistro = !rdr.IsDBNull(5) ? (System.DateTime)rdr["fecharegistro"] : System.DateTime.Now;
					lstUsuarioDepto.Add(_UsuarioDepto);
				}
				Base.CerrarConexion(SqlCnn);
				return lstUsuarioDepto;
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
				return lstUsuarioDepto;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public UsuarioDepto BuscarUsuarioDepto(System.Int32 idusuariodepto)
		{
			UsuarioDepto _UsuarioDepto= new UsuarioDepto();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioDepto_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuariodepto", idusuariodepto);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_UsuarioDepto.idusuariodepto = (System.Int32)rdr["idusuariodepto"];
					_UsuarioDepto.iddepartamento = (System.String)rdr["iddepartamento"];
					_UsuarioDepto.idcargo = (System.Int32)rdr["idcargo"];
					_UsuarioDepto.idempresa = (System.Int32)rdr["idempresa"];
					_UsuarioDepto.idusuario = (System.String)rdr["idusuario"];
					_UsuarioDepto.fecharegistro = !rdr.IsDBNull(5) ? (System.DateTime)rdr["fecharegistro"] : System.DateTime.Now;
				}
				Base.CerrarConexion(SqlCnn);
				return _UsuarioDepto;
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
				return _UsuarioDepto;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarUsuarioDepto(UsuarioDepto _UsuarioDepto)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioDepto_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDUsuarioDepto = new SqlParameter();
				pIDUsuarioDepto.ParameterName = "@IDUsuarioDepto";
				pIDUsuarioDepto.Value = 0;
				SqlCmd.Parameters.Add(pIDUsuarioDepto);
				pIDUsuarioDepto.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@iddepartamento", _UsuarioDepto.iddepartamento);
				SqlCmd.Parameters.AddWithValue("@idcargo", _UsuarioDepto.idcargo);
				SqlCmd.Parameters.AddWithValue("@idempresa", _UsuarioDepto.idempresa);
				SqlCmd.Parameters.AddWithValue("@idusuario", _UsuarioDepto.idusuario);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _UsuarioDepto.fecharegistro);

				SqlCmd.ExecuteNonQuery();
				_UsuarioDepto.idusuariodepto = (System.Int32)pIDUsuarioDepto.Value;
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
		public ActionResult ActualizarUsuarioDepto(UsuarioDepto _UsuarioDepto)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioDepto_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuariodepto", _UsuarioDepto.idusuariodepto);
				SqlCmd.Parameters.AddWithValue("@iddepartamento", _UsuarioDepto.iddepartamento);
				SqlCmd.Parameters.AddWithValue("@idcargo", _UsuarioDepto.idcargo);
				SqlCmd.Parameters.AddWithValue("@idempresa", _UsuarioDepto.idempresa);
				SqlCmd.Parameters.AddWithValue("@idusuario", _UsuarioDepto.idusuario);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _UsuarioDepto.fecharegistro);

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
		public ActionResult EliminarUsuarioDepto(UsuarioDepto _UsuarioDepto)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioDepto_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuariodepto", _UsuarioDepto.idusuariodepto);

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
