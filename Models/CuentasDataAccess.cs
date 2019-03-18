using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class CuentasDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Cuentas> ConsultarCuentas()
		{
			List<Cuentas> lstCuentas = new List<Cuentas>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cuentas_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Cuentas _Cuentas= new Cuentas();
					_Cuentas.idcuenta = (System.String)rdr["idcuenta"];
					_Cuentas.idcentral = (System.Int32)rdr["idcentral"];
					_Cuentas.etiqueta = (System.String)rdr["etiqueta"];
					_Cuentas.descripcion = !rdr.IsDBNull(3) ? (System.String)rdr["descripcion"] : "";
					lstCuentas.Add(_Cuentas);
				}
				Base.CerrarConexion(SqlCnn);
				return lstCuentas;
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
				return lstCuentas;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Cuentas BuscarCuentas(System.String idcuenta,System.Int32 idcentral)
		{
			Cuentas _Cuentas= new Cuentas();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cuentas_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcuenta", idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", idcentral);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Cuentas.idcuenta = (System.String)rdr["idcuenta"];
					_Cuentas.idcentral = (System.Int32)rdr["idcentral"];
					_Cuentas.etiqueta = (System.String)rdr["etiqueta"];
					_Cuentas.descripcion = !rdr.IsDBNull(3) ? (System.String)rdr["descripcion"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _Cuentas;
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
				return _Cuentas;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarCuentas(Cuentas _Cuentas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cuentas_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcuenta", _Cuentas.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Cuentas.idcentral);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Cuentas.etiqueta);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Cuentas.descripcion);

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
		public ActionResult ActualizarCuentas(Cuentas _Cuentas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cuentas_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcuenta", _Cuentas.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Cuentas.idcentral);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Cuentas.etiqueta);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Cuentas.descripcion);

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
		public ActionResult EliminarCuentas(Cuentas _Cuentas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cuentas_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcuenta", _Cuentas.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Cuentas.idcentral);

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
