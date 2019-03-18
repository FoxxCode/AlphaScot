using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Models
{
	public class PaisesDataAccess
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Paises> ConsultarPaises()
		{
			List<Paises> lstPaises = new List<Paises>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Paises_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Paises _Paises= new Paises();
					_Paises.idpais = (System.Int16)rdr["idpais"];
					_Paises.descripcion = (System.String)rdr["descripcion"];
					lstPaises.Add(_Paises);
				}
				Base.CerrarConexion(SqlCnn);
				return lstPaises;
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
				return lstPaises;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Paises BuscarPaises(System.Int16 idpais)
		{
			Paises _Paises= new Paises();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Paises_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpais", idpais);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Paises.idpais = (System.Int16)rdr["idpais"];
					_Paises.descripcion = (System.String)rdr["descripcion"];
				}
				Base.CerrarConexion(SqlCnn);
				return _Paises;
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
				return _Paises;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public int InsertarPaises(Paises _Paises)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Paises_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pidPais = new SqlParameter();
				pidPais.ParameterName = "@idPais";
				pidPais.Value = 0;
				SqlCmd.Parameters.Add(pidPais);
				pidPais.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _Paises.descripcion);

				SqlCmd.ExecuteNonQuery();
                _Paises.idpais = Convert.ToInt16(pidPais.Value);
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
		public int ActualizarPaises(Paises _Paises)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Paises_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpais", _Paises.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Paises.descripcion);

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
		public int EliminarPaises(Paises _Paises)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Paises_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpais", _Paises.idpais);

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
