using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class GruposLineasDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<GruposLineas> ConsultarGruposLineas()
		{
			List<GruposLineas> lstGruposLineas = new List<GruposLineas>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposLineas_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GruposLineas _GruposLineas= new GruposLineas();
					_GruposLineas.idgrupo = (System.Int32)rdr["idgrupo"];
					_GruposLineas.idcentral = (System.Int32)rdr["idcentral"];
					_GruposLineas.descripcion = !rdr.IsDBNull(2) ? (System.String)rdr["descripcion"] : "";
					lstGruposLineas.Add(_GruposLineas);
				}
				Base.CerrarConexion(SqlCnn);
				return lstGruposLineas;
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
				return lstGruposLineas;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public GruposLineas BuscarGruposLineas(System.Int32 idgrupo)
		{
			GruposLineas _GruposLineas= new GruposLineas();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposLineas_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", idgrupo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_GruposLineas.idgrupo = (System.Int32)rdr["idgrupo"];
					_GruposLineas.idcentral = (System.Int32)rdr["idcentral"];
					_GruposLineas.descripcion = !rdr.IsDBNull(2) ? (System.String)rdr["descripcion"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _GruposLineas;
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
				return _GruposLineas;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarGruposLineas(GruposLineas _GruposLineas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposLineas_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDGrupo = new SqlParameter();
				pIDGrupo.ParameterName = "@IDGrupo";
				pIDGrupo.Value = 0;
				SqlCmd.Parameters.Add(pIDGrupo);
				pIDGrupo.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposLineas.idcentral);
				SqlCmd.Parameters.AddWithValue("@descripcion", _GruposLineas.descripcion);

				SqlCmd.ExecuteNonQuery();
				_GruposLineas.idgrupo = (System.Int32)pIDGrupo.Value;
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
		public ActionResult ActualizarGruposLineas(GruposLineas _GruposLineas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposLineas_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposLineas.idgrupo);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposLineas.idcentral);
				SqlCmd.Parameters.AddWithValue("@descripcion", _GruposLineas.descripcion);

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
		public ActionResult EliminarGruposLineas(GruposLineas _GruposLineas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposLineas_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposLineas.idgrupo);

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
