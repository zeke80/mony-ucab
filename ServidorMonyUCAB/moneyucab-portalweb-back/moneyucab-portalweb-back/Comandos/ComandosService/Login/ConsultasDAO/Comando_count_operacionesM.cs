using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_Count_OperacionesM
    {
        private int _idtipooperacion;


        public Comando_Count_OperacionesM(int Idtipooperacion)
        {
            this._idtipooperacion = Idtipooperacion;
        }

         public int Ejecutar()
        {
            DAOBase dao = FabricaDAO.CrearDaoBase();
            return dao.count_operacionesmonedero(this._idtipooperacion);
        }
    }
}
