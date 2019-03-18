using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class CosteoDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Costeo> ConsultarCosteo()
		{
			List<Costeo> lstCosteo = new List<Costeo>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Costeo_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Costeo _Costeo= new Costeo();
					_Costeo.idllamada = (System.Guid)rdr["idllamada"];
					_Costeo.idinternousuario = (System.Int32)rdr["idinternousuario"];
					_Costeo.idusuariodepto = (System.Int32)rdr["idusuariodepto"];
					_Costeo.idinterno = (System.String)rdr["idinterno"];
					_Costeo.idusuariocuenta = (System.Int32)rdr["idusuariocuenta"];
					_Costeo.idcuenta = (System.String)rdr["idcuenta"];
					_Costeo.idcentral = (System.Int32)rdr["idcentral"];
					_Costeo.idlinea = (System.String)rdr["idlinea"];
					_Costeo.idproveedor = (System.Int32)rdr["idproveedor"];
					_Costeo.idtramo = (System.Int32)rdr["idtramo"];
					_Costeo.idtarifa = (System.Int32)rdr["idtarifa"];
					_Costeo.id = (System.Guid)rdr["id"];
					_Costeo.fecha = !rdr.IsDBNull(12) ? (System.DateTime)rdr["fecha"] : System.DateTime.Now;
					_Costeo.hora = !rdr.IsDBNull(13) ? (System.DateTime)rdr["hora"] : System.DateTime.Now;
					_Costeo.duracion = !rdr.IsDBNull(14) ? (System.DateTime)rdr["duracion"] : System.DateTime.Now;
					_Costeo.numero = !rdr.IsDBNull(15) ? (System.String)rdr["numero"] : "";
					_Costeo.costo = !rdr.IsDBNull(16) ? (System.Double)rdr["costo"] : (System.Double)0;
					lstCosteo.Add(_Costeo);
				}
				Base.CerrarConexion(SqlCnn);
				return lstCosteo;
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
				return lstCosteo;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Costeo BuscarCosteo(System.Guid idllamada)
		{
			Costeo _Costeo= new Costeo();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Costeo_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", idllamada);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Costeo.idllamada = (System.Guid)rdr["idllamada"];
					_Costeo.idinternousuario = (System.Int32)rdr["idinternousuario"];
					_Costeo.idusuariodepto = (System.Int32)rdr["idusuariodepto"];
					_Costeo.idinterno = (System.String)rdr["idinterno"];
					_Costeo.idusuariocuenta = (System.Int32)rdr["idusuariocuenta"];
					_Costeo.idcuenta = (System.String)rdr["idcuenta"];
					_Costeo.idcentral = (System.Int32)rdr["idcentral"];
					_Costeo.idlinea = (System.String)rdr["idlinea"];
					_Costeo.idproveedor = (System.Int32)rdr["idproveedor"];
					_Costeo.idtramo = (System.Int32)rdr["idtramo"];
					_Costeo.idtarifa = (System.Int32)rdr["idtarifa"];
					_Costeo.id = (System.Guid)rdr["id"];
					_Costeo.fecha = !rdr.IsDBNull(12) ? (System.DateTime)rdr["fecha"] : System.DateTime.Now;
					_Costeo.hora = !rdr.IsDBNull(13) ? (System.DateTime)rdr["hora"] : System.DateTime.Now;
					_Costeo.duracion = !rdr.IsDBNull(14) ? (System.DateTime)rdr["duracion"] : System.DateTime.Now;
					_Costeo.numero = !rdr.IsDBNull(15) ? (System.String)rdr["numero"] : "";
					_Costeo.costo = !rdr.IsDBNull(16) ? (System.Double)rdr["costo"] : (System.Double)0;
				}
				Base.CerrarConexion(SqlCnn);
				return _Costeo;
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
				return _Costeo;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarCosteo(Costeo _Costeo)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Costeo_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", _Costeo.idllamada);
				SqlCmd.Parameters.AddWithValue("@idinternousuario", _Costeo.idinternousuario);
				SqlCmd.Parameters.AddWithValue("@idusuariodepto", _Costeo.idusuariodepto);
				SqlCmd.Parameters.AddWithValue("@idinterno", _Costeo.idinterno);
				SqlCmd.Parameters.AddWithValue("@idusuariocuenta", _Costeo.idusuariocuenta);
				SqlCmd.Parameters.AddWithValue("@idcuenta", _Costeo.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Costeo.idcentral);
				SqlCmd.Parameters.AddWithValue("@idlinea", _Costeo.idlinea);
				SqlCmd.Parameters.AddWithValue("@idproveedor", _Costeo.idproveedor);
				SqlCmd.Parameters.AddWithValue("@idtramo", _Costeo.idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _Costeo.idtarifa);
				SqlCmd.Parameters.AddWithValue("@id", _Costeo.id);
				SqlCmd.Parameters.AddWithValue("@fecha", _Costeo.fecha);
				SqlCmd.Parameters.AddWithValue("@hora", _Costeo.hora);
				SqlCmd.Parameters.AddWithValue("@duracion", _Costeo.duracion);
				SqlCmd.Parameters.AddWithValue("@numero", _Costeo.numero);
				SqlCmd.Parameters.AddWithValue("@costo", _Costeo.costo);

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
		public ActionResult ActualizarCosteo(Costeo _Costeo)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Costeo_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", _Costeo.idllamada);
				SqlCmd.Parameters.AddWithValue("@idinternousuario", _Costeo.idinternousuario);
				SqlCmd.Parameters.AddWithValue("@idusuariodepto", _Costeo.idusuariodepto);
				SqlCmd.Parameters.AddWithValue("@idinterno", _Costeo.idinterno);
				SqlCmd.Parameters.AddWithValue("@idusuariocuenta", _Costeo.idusuariocuenta);
				SqlCmd.Parameters.AddWithValue("@idcuenta", _Costeo.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Costeo.idcentral);
				SqlCmd.Parameters.AddWithValue("@idlinea", _Costeo.idlinea);
				SqlCmd.Parameters.AddWithValue("@idproveedor", _Costeo.idproveedor);
				SqlCmd.Parameters.AddWithValue("@idtramo", _Costeo.idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _Costeo.idtarifa);
				SqlCmd.Parameters.AddWithValue("@id", _Costeo.id);
				SqlCmd.Parameters.AddWithValue("@fecha", _Costeo.fecha);
				SqlCmd.Parameters.AddWithValue("@hora", _Costeo.hora);
				SqlCmd.Parameters.AddWithValue("@duracion", _Costeo.duracion);
				SqlCmd.Parameters.AddWithValue("@numero", _Costeo.numero);
				SqlCmd.Parameters.AddWithValue("@costo", _Costeo.costo);

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
		public ActionResult EliminarCosteo(Costeo _Costeo)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Costeo_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", _Costeo.idllamada);

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
