using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class TarifaDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Tarifa> ConsultarTarifa()
		{
			List<Tarifa> lstTarifa = new List<Tarifa>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Tarifa_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Tarifa _Tarifa= new Tarifa();
					_Tarifa.idtarifa = (System.Int32)rdr["idtarifa"];
					_Tarifa.idservicio = (System.Int32)rdr["idservicio"];
					_Tarifa.descripcion = (System.String)rdr["descripcion"];
					_Tarifa.idciudad = (System.Int32)rdr["idciudad"];
					_Tarifa.idpais = !rdr.IsDBNull(4) ? (System.Int32)rdr["idpais"] : (System.Int32)0;
					_Tarifa.etiqueta = !rdr.IsDBNull(5) ? (System.String)rdr["etiqueta"] : "";
					lstTarifa.Add(_Tarifa);
				}
				Base.CerrarConexion(SqlCnn);
				return lstTarifa;
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
				return lstTarifa;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Tarifa BuscarTarifa(System.Int32 idtarifa)
		{
			Tarifa _Tarifa= new Tarifa();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Tarifa_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtarifa", idtarifa);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Tarifa.idtarifa = (System.Int32)rdr["idtarifa"];
					_Tarifa.idservicio = (System.Int32)rdr["idservicio"];
					_Tarifa.descripcion = (System.String)rdr["descripcion"];
					_Tarifa.idciudad = (System.Int32)rdr["idciudad"];
					_Tarifa.idpais = !rdr.IsDBNull(4) ? (System.Int32)rdr["idpais"] : (System.Int32)0;
					_Tarifa.etiqueta = !rdr.IsDBNull(5) ? (System.String)rdr["etiqueta"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _Tarifa;
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
				return _Tarifa;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarTarifa(Tarifa _Tarifa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Tarifa_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDTarifa = new SqlParameter();
				pIDTarifa.ParameterName = "@IDTarifa";
				pIDTarifa.Value = 0;
				SqlCmd.Parameters.Add(pIDTarifa);
				pIDTarifa.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idservicio", _Tarifa.idservicio);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Tarifa.descripcion);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Tarifa.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _Tarifa.idpais);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Tarifa.etiqueta);

				SqlCmd.ExecuteNonQuery();
				_Tarifa.idtarifa = (System.Int32)pIDTarifa.Value;
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
		public ActionResult ActualizarTarifa(Tarifa _Tarifa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Tarifa_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtarifa", _Tarifa.idtarifa);
				SqlCmd.Parameters.AddWithValue("@idservicio", _Tarifa.idservicio);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Tarifa.descripcion);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Tarifa.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _Tarifa.idpais);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Tarifa.etiqueta);

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
		public ActionResult EliminarTarifa(Tarifa _Tarifa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Tarifa_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtarifa", _Tarifa.idtarifa);

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
