using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace _20150926.BLL
{
    [DataObject]
    public class AreaBLL
    {
        private EntidadesBD20150926 context;

        public AreaBLL()
        {
            context = new EntidadesBD20150926();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Area> ObtenerAreas()
        {
            return this.context.Area.ToList();
        }

        public void Agregar(Area area)
        {
            context.Area.AddObject(area);
            context.SaveChanges();
        }

        public void Agregar(string Nombre, string Encargado)
        {
            Agregar(new Area() { Nombre = Nombre, Encargado = Encargado });
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Borrar(int AreaID)
        {
            foreach (var c in context.Carrera.Where(ca => ca.AreaID==AreaID))
            {
                context.Carrera.DeleteObject(c);
            }

            Area areaBorrar = context.Area.First(a => a.AreaID == AreaID);
            context.Area.DeleteObject(areaBorrar);
            context.SaveChanges();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Editar(string Nombre, string Encargado, int AreaID)
        {
            Area areaEditar = context.Area.First(a => a.AreaID == AreaID);
            areaEditar.Nombre = Nombre;
            areaEditar.Encargado = Encargado;
            context.SaveChanges();
        }
    }
}