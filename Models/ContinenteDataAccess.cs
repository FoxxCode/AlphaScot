using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class ContinenteDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Continente> ConsultarContinente()
		{
			List<Continente> lstContinente = new List<Continente>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Continente_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Continente _Continente= new Continente();
					_Continente.idcontinente = (System.Int32)rdr["idcontinente"];
					_Continente.descripcion = (System.String)rdr["descripcion"];
					lstContinente.Add(_Continente);
				}
				Base.CerrarConexion(SqlCnn);
				return lstContinente;
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
				return lstContinente;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Continente BuscarContinente(System.Int32 idcontinente)
		{
			Continente _Continente= new Continente();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Continente_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcontinente", idcontinente);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Continente.idcontinente = (System.Int32)rdr["idcontinente"];
					_Continente.descripcion = (System.String)rdr["descripcion"];
				}
				Base.CerrarConexion(SqlCnn);
				return _Continente;
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
				return _Continente;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarContinente(Continente _Continente)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Continente_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcontinente", _Continente.idcontinente);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Continente.descripcion);

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
		public ActionResult ActualizarContinente(Continente _Continente)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Continente_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcontinente", _Continente.idcontinente);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Continente.descripcion);

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
		public ActionResult EliminarContinente(Continente _Continente)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Continente_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcontinente", _Continente.idcontinente);

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
