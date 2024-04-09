using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection objConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT p.idRol, NombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.idRol = p.idRol");
                    query.AppendLine("inner join Usuario u on u.idRol = r.idRol");
                    query.AppendLine("where u.idUsuario = @idUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConexion);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    objConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                objRol = new Rol() { idRol = Convert.ToInt32(dr["idRol"]) },
                                NombreMenu = dr["NombreMenu"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }

            return lista;
        }
    }
}
