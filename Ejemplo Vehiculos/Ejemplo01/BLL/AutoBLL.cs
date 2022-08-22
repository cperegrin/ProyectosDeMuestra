using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ejemplo01.BLL
{
    class AutoBLL
    {
        private EntidadesEjemplo01 bd = new EntidadesEjemplo01();

        public List<Auto> GetAutos()
        {
            return bd.Auto.ToList();
        }

        public void Agregar(string marca, string modelo, string patente)
        {
            Auto auto = new Auto(){
                Marca = marca,
                Modelo = modelo,
                Patente = patente
            };

            bd.Auto.AddObject(auto);
            bd.SaveChanges();
        }

        public void Borrar(int autoID)
        {
            Auto autoBorrar = bd.Auto.Where(x => x.AutoID == autoID).FirstOrDefault();
            bd.Auto.DeleteObject(autoBorrar);
            bd.SaveChanges();
        }
    }
}
