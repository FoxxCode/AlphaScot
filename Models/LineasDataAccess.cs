using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class LineasDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Lineas> ConsultarLineas()
		{
			List<Lineas> lstLineas = new List<Lineas>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Lineas_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Lineas _Lineas= new Lineas();
					_Lineas.idlinea = (System.String)rdr["idlinea"];
					_Lineas.idcentral = (System.Int32)rdr["idcentral"];
					_Lineas.idproveedor = (System.Int32)rdr["idproveedor"];
					_Lineas.etiqueta = !rdr.IsDBNull(3) ? (System.String)rdr["etiqueta"] : "";
					_Lineas.descripcion = (System.String)rdr["descripcion"];
					_Lineas.numero = (System.String)rdr["numero"];
					_Lineas.reportaentrada = (System.Boolean)rdr["reportaentrada"];
					_Lineas.reportasalida = (System.Boolean)rdr["reportasalida"];
					lstLineas.Add(_Lineas);
				}
				Base.CerrarConexion(SqlCnn);
				return lstLineas;
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
				return lstLineas;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Lineas BuscarLineas(System.String idlinea,System.Int32 idcentral)
		{
			Lineas _Lineas= new Lineas();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Lineas_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idlinea", idlinea);
				SqlCmd.Parameters.AddWithValue("@idcentral", idcentral);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Lineas.idlinea = (System.String)rdr["idlinea"];
					_Lineas.idcentral = (System.Int32)rdr["idcentral"];
					_Lineas.idproveedor = (System.Int32)rdr["idproveedor"];
					_Lineas.etiqueta = !rdr.IsDBNull(3) ? (System.String)rdr["etiqueta"] : "";
					_Lineas.descripcion = (System.String)rdr["descripcion"];
					_Lineas.numero = (System.String)rdr["numero"];
					_Lineas.reportaentrada = (System.Boolean)rdr["reportaentrada"];
					_Lineas.reportasalida = (System.Boolean)rdr["reportasalida"];
				}
				Base.CerrarConexion(SqlCnn);
				return _Lineas;
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
				return _Lineas;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarLineas(Lineas _Lineas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Lineas_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idlinea", _Lineas.idlinea);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Lineas.idcentral);
				SqlCmd.Parameters.AddWithValue("@idproveedor", _Lineas.idproveedor);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Lineas.etiqueta);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Lineas.descripcion);
				SqlCmd.Parameters.AddWithValue("@numero", _Lineas.numero);
				SqlCmd.Parameters.AddWithValue("@reportaentrada", _Lineas.reportaentrada);
				SqlCmd.Parameters.AddWithValue("@reportasalida", _Lineas.reportasalida);

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
		public ActionResult ActualizarLineas(Lineas _Lineas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Lineas_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idlinea", _Lineas.idlinea);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Lineas.idcentral);
				SqlCmd.Parameters.AddWithValue("@idproveedor", _Lineas.idproveedor);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Lineas.etiqueta);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Lineas.descripcion);
				SqlCmd.Parameters.AddWithValue("@numero", _Lineas.numero);
				SqlCmd.Parameters.AddWithValue("@reportaentrada", _Lineas.reportaentrada);
				SqlCmd.Parameters.AddWithValue("@reportasalida", _Lineas.reportasalida);

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
		public ActionResult EliminarLineas(Lineas _Lineas)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Lineas_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idlinea", _Lineas.idlinea);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Lineas.idcentral);

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
