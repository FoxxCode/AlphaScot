using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class GruposCuentasCuentaDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<GruposCuentasCuenta> ConsultarGruposCuentasCuenta()
		{
			List<GruposCuentasCuenta> lstGruposCuentasCuenta = new List<GruposCuentasCuenta>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposCuentasCuenta_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GruposCuentasCuenta _GruposCuentasCuenta= new GruposCuentasCuenta();
					_GruposCuentasCuenta.idcuenta = (System.String)rdr["idcuenta"];
					_GruposCuentasCuenta.idcentral = (System.Int32)rdr["idcentral"];
					_GruposCuentasCuenta.idgrupo = (System.Int32)rdr["idgrupo"];
					_GruposCuentasCuenta.fecharegistro = (System.DateTime)rdr["fecharegistro"];
					lstGruposCuentasCuenta.Add(_GruposCuentasCuenta);
				}
				Base.CerrarConexion(SqlCnn);
				return lstGruposCuentasCuenta;
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
				return lstGruposCuentasCuenta;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public GruposCuentasCuenta BuscarGruposCuentasCuenta(System.String idcuenta,System.Int32 idcentral,System.Int32 idgrupo)
		{
			GruposCuentasCuenta _GruposCuentasCuenta= new GruposCuentasCuenta();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposCuentasCuenta_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcuenta", idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", idcentral);
				SqlCmd.Parameters.AddWithValue("@idgrupo", idgrupo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_GruposCuentasCuenta.idcuenta = (System.String)rdr["idcuenta"];
					_GruposCuentasCuenta.idcentral = (System.Int32)rdr["idcentral"];
					_GruposCuentasCuenta.idgrupo = (System.Int32)rdr["idgrupo"];
					_GruposCuentasCuenta.fecharegistro = (System.DateTime)rdr["fecharegistro"];
				}
				Base.CerrarConexion(SqlCnn);
				return _GruposCuentasCuenta;
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
				return _GruposCuentasCuenta;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarGruposCuentasCuenta(GruposCuentasCuenta _GruposCuentasCuenta)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposCuentasCuenta_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcuenta", _GruposCuentasCuenta.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposCuentasCuenta.idcentral);
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposCuentasCuenta.idgrupo);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _GruposCuentasCuenta.fecharegistro);

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
		public ActionResult ActualizarGruposCuentasCuenta(GruposCuentasCuenta _GruposCuentasCuenta)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposCuentasCuenta_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcuenta", _GruposCuentasCuenta.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposCuentasCuenta.idcentral);
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposCuentasCuenta.idgrupo);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _GruposCuentasCuenta.fecharegistro);

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
		public ActionResult EliminarGruposCuentasCuenta(GruposCuentasCuenta _GruposCuentasCuenta)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposCuentasCuenta_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcuenta", _GruposCuentasCuenta.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposCuentasCuenta.idcentral);
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposCuentasCuenta.idgrupo);

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
