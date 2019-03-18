using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class GrupoLineaLineasDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<GrupoLineaLineas> ConsultarGrupoLineaLineas()
		{
			List<GrupoLineaLineas> lstGrupoLineaLineas = new List<GrupoLineaLineas>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrupoLineaLineas_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GrupoLineaLineas _GrupoLineaLineas= new GrupoLineaLineas();
					_GrupoLineaLineas.idgrupo = (System.Int32)rdr["idgrupo"];
					_GrupoLineaLineas.idlinea = (System.String)rdr["idlinea"];
					_GrupoLineaLineas.idcentral = (System.Int32)rdr["idcentral"];
					_GrupoLineaLineas.fecharegistro = (System.DateTime)rdr["fecharegistro"];
					lstGrupoLineaLineas.Add(_GrupoLineaLineas);
				}
				Base.CerrarConexion(SqlCnn);
				return lstGrupoLineaLineas;
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
				return lstGrupoLineaLineas;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public GrupoLineaLineas BuscarGrupoLineaLineas(System.Int32 idgrupo,System.String idlinea,System.Int32 idcentral)
		{
			GrupoLineaLineas _GrupoLineaLineas= new GrupoLineaLineas();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrupoLineaLineas_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", idgrupo);
				SqlCmd.Parameters.AddWithValue("@idlinea", idlinea);
				SqlCmd.Parameters.AddWithValue("@idcentral", idcentral);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_GrupoLineaLineas.idgrupo = (System.Int32)rdr["idgrupo"];
					_GrupoLineaLineas.idlinea = (System.String)rdr["idlinea"];
					_GrupoLineaLineas.idcentral = (System.Int32)rdr["idcentral"];
					_GrupoLineaLineas.fecharegistro = (System.DateTime)rdr["fecharegistro"];
				}
				Base.CerrarConexion(SqlCnn);
				return _GrupoLineaLineas;
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
				return _GrupoLineaLineas;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarGrupoLineaLineas(GrupoLineaLineas _GrupoLineaLineas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrupoLineaLineas_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GrupoLineaLineas.idgrupo);
				SqlCmd.Parameters.AddWithValue("@idlinea", _GrupoLineaLineas.idlinea);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GrupoLineaLineas.idcentral);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _GrupoLineaLineas.fecharegistro);

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
		public ActionResult ActualizarGrupoLineaLineas(GrupoLineaLineas _GrupoLineaLineas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrupoLineaLineas_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GrupoLineaLineas.idgrupo);
				SqlCmd.Parameters.AddWithValue("@idlinea", _GrupoLineaLineas.idlinea);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GrupoLineaLineas.idcentral);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _GrupoLineaLineas.fecharegistro);

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
		public ActionResult EliminarGrupoLineaLineas(GrupoLineaLineas _GrupoLineaLineas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrupoLineaLineas_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GrupoLineaLineas.idgrupo);
				SqlCmd.Parameters.AddWithValue("@idlinea", _GrupoLineaLineas.idlinea);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GrupoLineaLineas.idcentral);

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
