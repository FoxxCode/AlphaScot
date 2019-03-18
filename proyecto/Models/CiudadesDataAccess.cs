using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Models
{
	public class CiudadesDataAccess
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Ciudades> ConsultarCiudades()
		{
			List<Ciudades> lstCiudades = new List<Ciudades>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Ciudades _Ciudades= new Ciudades();
					_Ciudades.idciudad = (System.Int16)rdr["idciudad"];
					_Ciudades.descripcion = (System.String)rdr["descripcion"];
					_Ciudades.idpais = (System.Int16)rdr["idpais"];
					lstCiudades.Add(_Ciudades);
				}
				Base.CerrarConexion(SqlCnn);
				return lstCiudades;
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						throw new Exception(se.Message, XcpSQL);
					else
						throw new Exception("Error en Operacion de Consulta de Datos",XcpSQL);
				}
				return lstCiudades;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Ciudades BuscarCiudades(System.Int16 idciudad)
		{
			Ciudades _Ciudades= new Ciudades();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idciudad", idciudad);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Ciudades.idciudad = (System.Int16)rdr["idciudad"];
					_Ciudades.descripcion = (System.String)rdr["descripcion"];
					_Ciudades.idpais = (System.Int16)rdr["idpais"];
				}
				Base.CerrarConexion(SqlCnn);
				return _Ciudades;
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						throw new Exception(se.Message, XcpSQL);
					else
						throw new Exception("Error en Operacion en Busqueda de Datos",XcpSQL);
				}
				return _Ciudades;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public int InsertarCiudades(Ciudades _Ciudades)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIdCiudad = new SqlParameter();
				pIdCiudad.ParameterName = "@IdCiudad";
				pIdCiudad.Value = 0;
				SqlCmd.Parameters.Add(pIdCiudad);
				pIdCiudad.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _Ciudades.descripcion);
				SqlCmd.Parameters.AddWithValue("@idpais", _Ciudades.idpais);

				SqlCmd.ExecuteNonQuery();
				_Ciudades.idciudad = Convert.ToInt16(pIdCiudad.Value);
				Base.CerrarConexion(SqlCnn);
				return 1;
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						throw new Exception(se.Message, XcpSQL);
					else
						throw new Exception("Error en Operacion de Insercion de Datos",XcpSQL);
				}
				return 0;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public int ActualizarCiudades(Ciudades _Ciudades)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idciudad", _Ciudades.idciudad);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Ciudades.descripcion);
				SqlCmd.Parameters.AddWithValue("@idpais", _Ciudades.idpais);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				return 1;
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						throw new Exception(se.Message, XcpSQL);
					else
						throw new Exception("Error en Operacion de Actualizacion de Datos",XcpSQL);
				}
				return 0;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public int EliminarCiudades(Ciudades _Ciudades)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idciudad", _Ciudades.idciudad);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				return 1;
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						throw new Exception(se.Message, XcpSQL);
					else
						throw new Exception("Error en Operacion de Eliminacion de Datos",XcpSQL);
				}
				return 0;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
	}
}
