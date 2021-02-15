using Proyecto1.Administracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1.Instrucciones
{
    public class Writeln : Funcion
    {
        public Writeln(int fila, int columna):base(new LinkedList<object>(),"writeln",fila, columna)
        {
        }

        /*Esta función abstracta es para la declaración de la función. La hago como que si se tratara de una instrucción más. 
         * **/
        public override Objeto ejecutar()
        {
            // aqui agrego la función a la lista de funciones de la singleton
            bool res= MasterClass.Instance.addFunction(this);
            /*
            
            ... agregar validaciones

             */
            return null;

        }


        /*
         * Esta función abstracta se ejecuta cuando se llama a esta función
         * **/
        public override Objeto ejecutarFuncion(LinkedList<Objeto> parametros_actuales)
        {
            MasterClass.Instance.addOutput(parametros_actuales.First.Value.getValue().ToString());
            return null;
        }
    }
}
