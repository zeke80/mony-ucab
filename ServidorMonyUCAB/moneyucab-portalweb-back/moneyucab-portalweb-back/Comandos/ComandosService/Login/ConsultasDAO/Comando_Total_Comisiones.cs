using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_Total_Comisiones
    {
        


        public Comando_Total_Comisiones()
        {
            
        }

        public int Ejecutar()
        {
            DAOBase dao = FabricaDAO.CrearDaoBase();
            return dao.total_comisiones();
        }
    }
}
