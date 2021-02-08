using Proyecto1.Administracion;
using Proyecto1.Objetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1.Expresiones
{
    public class Constante : NodoAST
    {
        Objeto valor;
        public Constante(int fila, int columna, Objeto valor): base(fila, columna)
        {
            this.valor = valor;
        }
        public override Objeto ejecutar()
        {
            return this.valor;
        }
    }
}
