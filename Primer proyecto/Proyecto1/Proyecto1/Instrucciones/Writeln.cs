using Proyecto1.Administracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1.Instrucciones
{
    public class Writeln : NodoAST
    {
        private NodoAST expresion;
        public Writeln(int fila, int columna, NodoAST expresion):base(fila, columna)
        {
            this.expresion = expresion;
        }
        public override Objeto ejecutar()
        {
            Objeto res = this.expresion.ejecutar();
            MasterClass.Instance.addOutput(res.getValue().ToString());
            return null;
        }
    }
}
