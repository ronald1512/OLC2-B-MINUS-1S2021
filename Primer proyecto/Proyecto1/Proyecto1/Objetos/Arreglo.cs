using Proyecto1.Administracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1.Objetos
{
    /*
     * Clase dedicada al manejo de arrelgos. 
     * 
     * Esta es una sugerencia de implementación. Consiste en que cada instancia de esta clase, representa
     * a una sola dimensión de un arreglo. Si se trata de un arreglo multidimensional, cada elemento de la 
     * LinkedList<Objeto> valor, es UN arreglo, y asi sucesivamente...
     * 
     * **/
    public class Arreglo : Objeto
    {
        LinkedList<Objeto> valor;   // contenido de la dimensión
        int lim_inf, lim_sup;       //limite inferior y límite superior de la dimension
        Objeto tipo_contenido;      //tipo del contenido que tendrá
        public Arreglo() : base(Tipo.ARRAY)
        {

        }
        public override object getValue()
        {
            throw new NotImplementedException();
        }

        public override string toString()
        {
            throw new NotImplementedException();
        }
    }
}
