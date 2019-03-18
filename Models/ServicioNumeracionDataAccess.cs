using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class ServicioNumeracionDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<ServicioNumeracion> ConsultarServicioNumeracion()
		{
			List<ServicioNumeracion> lstServicioNumeracion = new List<ServicioNumeracion>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ServicioNumeracion_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					ServicioNumeracion _ServicioNumeracion= new ServicioNumeracion();
					_ServicioNumeracion.idrango = (System.Int32)rdr["idrango"];
					_ServicioNumeracion.idservicio = (System.Int32)rdr["idservicio"];
					_ServicioNumeracion.idciudad = (System.Int32)rdr["idciudad"];
					_ServicioNumeracion.idpais = (System.Int32)rdr["idpais"];
					_ServicioNumeracion.descripcion = (System.String)rdr["descripcion"];
					_ServicioNumeracion.etiqueta = !rdr.IsDBNull(5) ? (System.String)rdr["etiqueta"] : "";
					_ServicioNumeracion.numeroinicio = (System.String)rdr["numeroinicio"];
					_ServicioNumeracion.numerofinal = (System.String)rdr["numerofinal"];
					lstServicioNumeracion.Add(_ServicioNumeracion);
				}
				Base.CerrarConexion(SqlCnn);
				return lstServicioNumeracion;
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
				return lstServicioNumeracion;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ServicioNumeracion BuscarServicioNumeracion(System.Int32 idrango,System.Int32 idservicio)
		{
			ServicioNumeracion _ServicioNumeracion= new ServicioNumeracion();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ServicioNumeracion_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrango", idrango);
				SqlCmd.Parameters.AddWithValue("@idservicio", idservicio);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_ServicioNumeracion.idrango = (System.Int32)rdr["idrango"];
					_ServicioNumeracion.idservicio = (System.Int32)rdr["idservicio"];
					_ServicioNumeracion.idciudad = (System.Int32)rdr["idciudad"];
					_ServicioNumeracion.idpais = (System.Int32)rdr["idpais"];
					_ServicioNumeracion.descripcion = (System.String)rdr["descripcion"];
					_ServicioNumeracion.etiqueta = !rdr.IsDBNull(5) ? (System.String)rdr["etiqueta"] : "";
					_ServicioNumeracion.numeroinicio = (System.String)rdr["numeroinicio"];
					_ServicioNumeracion.numerofinal = (System.String)rdr["numerofinal"];
				}
				Base.CerrarConexion(SqlCnn);
				return _ServicioNumeracion;
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
				return _ServicioNumeracion;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarServicioNumeracion(ServicioNumeracion _ServicioNumeracion)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ServicioNumeracion_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDRango = new SqlParameter();
				pIDRango.ParameterName = "@IDRango";
				pIDRango.Value = 0;
				SqlCmd.Parameters.Add(pIDRango);
				pIDRango.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idservicio", _ServicioNumeracion.idservicio);
				SqlCmd.Parameters.AddWithValue("@idciudad", _ServicioNumeracion.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _ServicioNumeracion.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _ServicioNumeracion.descripcion);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _ServicioNumeracion.etiqueta);
				SqlCmd.Parameters.AddWithValue("@numeroinicio", _ServicioNumeracion.numeroinicio);
				SqlCmd.Parameters.AddWithValue("@numerofinal", _ServicioNumeracion.numerofinal);

				SqlCmd.ExecuteNonQuery();
				_ServicioNumeracion.idrango = (System.Int32)pIDRango.Value;
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
		public ActionResult ActualizarServicioNumeracion(ServicioNumeracion _ServicioNumeracion)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ServicioNumeracion_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrango", _ServicioNumeracion.idrango);
				SqlCmd.Parameters.AddWithValue("@idservicio", _ServicioNumeracion.idservicio);
				SqlCmd.Parameters.AddWithValue("@idciudad", _ServicioNumeracion.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _ServicioNumeracion.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _ServicioNumeracion.descripcion);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _ServicioNumeracion.etiqueta);
				SqlCmd.Parameters.AddWithValue("@numeroinicio", _ServicioNumeracion.numeroinicio);
				SqlCmd.Parameters.AddWithValue("@numerofinal", _ServicioNumeracion.numerofinal);

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
		public ActionResult EliminarServicioNumeracion(ServicioNumeracion _ServicioNumeracion)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ServicioNumeracion_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrango", _ServicioNumeracion.idrango);
				SqlCmd.Parameters.AddWithValue("@idservicio", _ServicioNumeracion.idservicio);

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
