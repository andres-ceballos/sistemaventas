using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_Permiso objCD_Permiso = new CD_Permiso();

        public List<Permiso> Listar(int idUsuario)
        {
            return objCD_Permiso.Listar(idUsuario);
        }
    }
}
