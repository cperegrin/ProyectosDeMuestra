using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace _20150926.BLL
{
    [DataObject]
    public class CarreraBLL
    {
        private EntidadesBD20150926 context;

        public CarreraBLL()
        {
            context = new EntidadesBD20150926();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Carrera> ObtenerCarreras(){
            return context.Carrera.ToList();
        }

        public void Agregar(string Nombre, int Duracion, int AreaID)
        {
            Carrera nuevaCarrera = new Carrera()
            {
                Nombre = Nombre,
                Duracion = Duracion,
                AreaID = AreaID
            };

            context.Carrera.AddObject(nuevaCarrera);
            context.SaveChanges();
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Borrar(int CarreraID)
        {
            context.Carrera.DeleteObject(context.Carrera.First(c => c.CarreraID == CarreraID));
            context.SaveChanges();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Editar(string Nombre, int Duracion, int AreaID, int CarreraID)
        {
            Carrera carrEditar = context.Carrera.First(c => c.CarreraID == CarreraID);
            carrEditar.Nombre = Nombre;
            carrEditar.Duracion = Duracion;
            carrEditar.AreaID = AreaID;
            context.SaveChanges();
        }
    }
}