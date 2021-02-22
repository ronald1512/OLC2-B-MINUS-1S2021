using Proyecto1.Administracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1.Objetos
{
    /*
     * Clase Type:
     * Para este proyecto los types solo serán de Objects. Por ello se sugiere esta estructura. 
     * - Contendrá variables internas.
     * **/
    class Type : Objeto
    {
        String name;
        LinkedList<Objeto> variables; /*Podrían tener aqui una TS para el manejo de las variables internas... Aqui 
                                       hace falta establecer la relacion entre Objeto y nombre.  
                                       */
        public Type() : base(Tipo.TYPE)
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
