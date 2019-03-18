using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class UsuarioCuentaDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<UsuarioCuenta> ConsultarUsuarioCuenta()
		{
			List<UsuarioCuenta> lstUsuarioCuenta = new List<UsuarioCuenta>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioCuenta_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					UsuarioCuenta _UsuarioCuenta= new UsuarioCuenta();
					_UsuarioCuenta.idusuariocuenta = (System.Int32)rdr["idusuariocuenta"];
					_UsuarioCuenta.idcuenta = (System.String)rdr["idcuenta"];
					_UsuarioCuenta.idcentral = (System.Int32)rdr["idcentral"];
					_UsuarioCuenta.idusuario = (System.String)rdr["idusuario"];
					_UsuarioCuenta.idempresa = (System.Int32)rdr["idempresa"];
					_UsuarioCuenta.fecharegistro = (System.DateTime)rdr["fecharegistro"];
					lstUsuarioCuenta.Add(_UsuarioCuenta);
				}
				Base.CerrarConexion(SqlCnn);
				return lstUsuarioCuenta;
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
				return lstUsuarioCuenta;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public UsuarioCuenta BuscarUsuarioCuenta(System.Int32 idusuariocuenta)
		{
			UsuarioCuenta _UsuarioCuenta= new UsuarioCuenta();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioCuenta_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuariocuenta", idusuariocuenta);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_UsuarioCuenta.idusuariocuenta = (System.Int32)rdr["idusuariocuenta"];
					_UsuarioCuenta.idcuenta = (System.String)rdr["idcuenta"];
					_UsuarioCuenta.idcentral = (System.Int32)rdr["idcentral"];
					_UsuarioCuenta.idusuario = (System.String)rdr["idusuario"];
					_UsuarioCuenta.idempresa = (System.Int32)rdr["idempresa"];
					_UsuarioCuenta.fecharegistro = (System.DateTime)rdr["fecharegistro"];
				}
				Base.CerrarConexion(SqlCnn);
				return _UsuarioCuenta;
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
				return _UsuarioCuenta;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarUsuarioCuenta(UsuarioCuenta _UsuarioCuenta)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioCuenta_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDUsuarioCuenta = new SqlParameter();
				pIDUsuarioCuenta.ParameterName = "@IDUsuarioCuenta";
				pIDUsuarioCuenta.Value = 0;
				SqlCmd.Parameters.Add(pIDUsuarioCuenta);
				pIDUsuarioCuenta.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idcuenta", _UsuarioCuenta.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _UsuarioCuenta.idcentral);
				SqlCmd.Parameters.AddWithValue("@idusuario", _UsuarioCuenta.idusuario);
				SqlCmd.Parameters.AddWithValue("@idempresa", _UsuarioCuenta.idempresa);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _UsuarioCuenta.fecharegistro);

				SqlCmd.ExecuteNonQuery();
				_UsuarioCuenta.idusuariocuenta = (System.Int32)pIDUsuarioCuenta.Value;
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
		public ActionResult ActualizarUsuarioCuenta(UsuarioCuenta _UsuarioCuenta)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioCuenta_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuariocuenta", _UsuarioCuenta.idusuariocuenta);
				SqlCmd.Parameters.AddWithValue("@idcuenta", _UsuarioCuenta.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _UsuarioCuenta.idcentral);
				SqlCmd.Parameters.AddWithValue("@idusuario", _UsuarioCuenta.idusuario);
				SqlCmd.Parameters.AddWithValue("@idempresa", _UsuarioCuenta.idempresa);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _UsuarioCuenta.fecharegistro);

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
		public ActionResult EliminarUsuarioCuenta(UsuarioCuenta _UsuarioCuenta)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UsuarioCuenta_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuariocuenta", _UsuarioCuenta.idusuariocuenta);

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
