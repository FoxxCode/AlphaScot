using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class CentralDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Central> ConsultarCentral()
		{
			List<Central> lstCentral = new List<Central>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Central_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Central _Central= new Central();
					_Central.idcentral = (System.Int32)rdr["idcentral"];
					_Central.idciudad = (System.Int32)rdr["idciudad"];
					_Central.idpais = (System.Int32)rdr["idpais"];
					_Central.idempresa = (System.Int32)rdr["idempresa"];
					_Central.descripcion = (System.String)rdr["descripcion"];
					_Central.codigo = (System.String)rdr["codigo"];
					_Central.procesaentrada = (System.Boolean)rdr["procesaentrada"];
					_Central.procesasalida = (System.Boolean)rdr["procesasalida"];
					_Central.procesacuentas = (System.Boolean)rdr["procesacuentas"];
					lstCentral.Add(_Central);
				}
				Base.CerrarConexion(SqlCnn);
				return lstCentral;
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
				return lstCentral;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Central BuscarCentral(System.Int32 idcentral)
		{
			Central _Central= new Central();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Central_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcentral", idcentral);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Central.idcentral = (System.Int32)rdr["idcentral"];
					_Central.idciudad = (System.Int32)rdr["idciudad"];
					_Central.idpais = (System.Int32)rdr["idpais"];
					_Central.idempresa = (System.Int32)rdr["idempresa"];
					_Central.descripcion = (System.String)rdr["descripcion"];
					_Central.codigo = (System.String)rdr["codigo"];
					_Central.procesaentrada = (System.Boolean)rdr["procesaentrada"];
					_Central.procesasalida = (System.Boolean)rdr["procesasalida"];
					_Central.procesacuentas = (System.Boolean)rdr["procesacuentas"];
				}
				Base.CerrarConexion(SqlCnn);
				return _Central;
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
				return _Central;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarCentral(Central _Central)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Central_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcentral", _Central.idcentral);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Central.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _Central.idpais);
				SqlCmd.Parameters.AddWithValue("@idempresa", _Central.idempresa);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Central.descripcion);
				SqlCmd.Parameters.AddWithValue("@codigo", _Central.codigo);
				SqlCmd.Parameters.AddWithValue("@procesaentrada", _Central.procesaentrada);
				SqlCmd.Parameters.AddWithValue("@procesasalida", _Central.procesasalida);
				SqlCmd.Parameters.AddWithValue("@procesacuentas", _Central.procesacuentas);

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
		public ActionResult ActualizarCentral(Central _Central)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Central_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcentral", _Central.idcentral);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Central.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _Central.idpais);
				SqlCmd.Parameters.AddWithValue("@idempresa", _Central.idempresa);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Central.descripcion);
				SqlCmd.Parameters.AddWithValue("@codigo", _Central.codigo);
				SqlCmd.Parameters.AddWithValue("@procesaentrada", _Central.procesaentrada);
				SqlCmd.Parameters.AddWithValue("@procesasalida", _Central.procesasalida);
				SqlCmd.Parameters.AddWithValue("@procesacuentas", _Central.procesacuentas);

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
		public ActionResult EliminarCentral(Central _Central)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Central_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcentral", _Central.idcentral);

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
