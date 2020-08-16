using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_Total_Operaciones
    {


        public Comando_Total_Operaciones()
        {
          
        }

         public int Ejecutar()
        {
            DAOBase dao = FabricaDAO.CrearDaoBase();
            return dao.total_operaciones();
        }
    }
}
