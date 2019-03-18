using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class GruposCuentasDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<GruposCuentas> ConsultarGruposCuentas()
		{
			List<GruposCuentas> lstGruposCuentas = new List<GruposCuentas>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposCuentas_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GruposCuentas _GruposCuentas= new GruposCuentas();
					_GruposCuentas.idgrupo = (System.Int32)rdr["idgrupo"];
					_GruposCuentas.idcentral = (System.Int32)rdr["idcentral"];
					_GruposCuentas.descripcion = (System.String)rdr["descripcion"];
					lstGruposCuentas.Add(_GruposCuentas);
				}
				Base.CerrarConexion(SqlCnn);
				return lstGruposCuentas;
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
				return lstGruposCuentas;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public GruposCuentas BuscarGruposCuentas(System.Int32 idgrupo)
		{
			GruposCuentas _GruposCuentas= new GruposCuentas();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposCuentas_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", idgrupo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_GruposCuentas.idgrupo = (System.Int32)rdr["idgrupo"];
					_GruposCuentas.idcentral = (System.Int32)rdr["idcentral"];
					_GruposCuentas.descripcion = (System.String)rdr["descripcion"];
				}
				Base.CerrarConexion(SqlCnn);
				return _GruposCuentas;
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
				return _GruposCuentas;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarGruposCuentas(GruposCuentas _GruposCuentas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposCuentas_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDGrupo = new SqlParameter();
				pIDGrupo.ParameterName = "@IDGrupo";
				pIDGrupo.Value = 0;
				SqlCmd.Parameters.Add(pIDGrupo);
				pIDGrupo.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposCuentas.idcentral);
				SqlCmd.Parameters.AddWithValue("@descripcion", _GruposCuentas.descripcion);

				SqlCmd.ExecuteNonQuery();
				_GruposCuentas.idgrupo = (System.Int32)pIDGrupo.Value;
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
		public ActionResult ActualizarGruposCuentas(GruposCuentas _GruposCuentas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposCuentas_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposCuentas.idgrupo);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposCuentas.idcentral);
				SqlCmd.Parameters.AddWithValue("@descripcion", _GruposCuentas.descripcion);

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
		public ActionResult EliminarGruposCuentas(GruposCuentas _GruposCuentas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposCuentas_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposCuentas.idgrupo);

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
