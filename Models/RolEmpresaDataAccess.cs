using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class RolEmpresaDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<RolEmpresa> ConsultarRolEmpresa()
		{
			List<RolEmpresa> lstRolEmpresa = new List<RolEmpresa>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_RolEmpresa_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					RolEmpresa _RolEmpresa= new RolEmpresa();
					_RolEmpresa.idrolempresa = (System.Int32)rdr["idrolempresa"];
					_RolEmpresa.idempresa = (System.Int32)rdr["idempresa"];
					_RolEmpresa.idrol = (System.Int32)rdr["idrol"];
					_RolEmpresa.fecharegistro = !rdr.IsDBNull(3) ? (System.DateTime)rdr["fecharegistro"] : System.DateTime.Now;
					lstRolEmpresa.Add(_RolEmpresa);
				}
				Base.CerrarConexion(SqlCnn);
				return lstRolEmpresa;
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
				return lstRolEmpresa;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public RolEmpresa BuscarRolEmpresa(System.Int32 idrolempresa)
		{
			RolEmpresa _RolEmpresa= new RolEmpresa();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_RolEmpresa_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrolempresa", idrolempresa);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_RolEmpresa.idrolempresa = (System.Int32)rdr["idrolempresa"];
					_RolEmpresa.idempresa = (System.Int32)rdr["idempresa"];
					_RolEmpresa.idrol = (System.Int32)rdr["idrol"];
					_RolEmpresa.fecharegistro = !rdr.IsDBNull(3) ? (System.DateTime)rdr["fecharegistro"] : System.DateTime.Now;
				}
				Base.CerrarConexion(SqlCnn);
				return _RolEmpresa;
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
				return _RolEmpresa;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarRolEmpresa(RolEmpresa _RolEmpresa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_RolEmpresa_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDRolEmpresa = new SqlParameter();
				pIDRolEmpresa.ParameterName = "@IDRolEmpresa";
				pIDRolEmpresa.Value = 0;
				SqlCmd.Parameters.Add(pIDRolEmpresa);
				pIDRolEmpresa.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idempresa", _RolEmpresa.idempresa);
				SqlCmd.Parameters.AddWithValue("@idrol", _RolEmpresa.idrol);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _RolEmpresa.fecharegistro);

				SqlCmd.ExecuteNonQuery();
				_RolEmpresa.idrolempresa = (System.Int32)pIDRolEmpresa.Value;
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
		public ActionResult ActualizarRolEmpresa(RolEmpresa _RolEmpresa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_RolEmpresa_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrolempresa", _RolEmpresa.idrolempresa);
				SqlCmd.Parameters.AddWithValue("@idempresa", _RolEmpresa.idempresa);
				SqlCmd.Parameters.AddWithValue("@idrol", _RolEmpresa.idrol);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _RolEmpresa.fecharegistro);

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
		public ActionResult EliminarRolEmpresa(RolEmpresa _RolEmpresa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_RolEmpresa_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrolempresa", _RolEmpresa.idrolempresa);

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
