using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1.Administracion
{
    public abstract class NodoAST
    {
        private int fila;
        private int columna;
        public NodoAST(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
        }
        public int getFila()
        {
            return this.fila;
        }
        public int getColumna()
        {
            return this.columna;
        }


        public abstract Objeto ejecutar(); //las instrucciones no retornan nada. En el caso de las expresiones,si retorna un objeto.  
    }
}
