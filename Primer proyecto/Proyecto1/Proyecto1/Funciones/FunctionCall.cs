using Proyecto1.Administracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1.Funciones
{
    public class FunctionCall : NodoAST
    {
        private LinkedList<NodoAST> parametros;     // lista de parámetros que el usuario le quiere enviar
        private string id;      //nombre de la función que quiero llamar

        public FunctionCall(LinkedList<NodoAST> parametros, string id, int fila, int columna):base(fila, columna)
        {
            this.parametros = parametros;
            this.id = id;
        }



        public override Objeto ejecutar()
        {
            //aqui vamos a llamar a la función que solicito, luego la ejecuto. 
            Funcion tmp=MasterClass.Instance.getFuncion(this.id);

            LinkedList<Objeto> resultados = new LinkedList<Objeto>();
            foreach(NodoAST nodo in this.parametros)
            {
                resultados.AddLast(nodo.ejecutar());
            }
            return tmp.ejecutarFuncion(resultados); //le mandamos los parametros actuales y la mandamos a ejecutar. 
        }
    }
}
