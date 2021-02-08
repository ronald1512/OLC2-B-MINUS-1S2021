using System;
using System.Collections.Generic;
using System.Text;
using Proyecto1.Administracion;
using Proyecto1.Objetos;

namespace Proyecto1.Expresiones
{
    public class Aritmetica : NodoAST
    {
        public enum TipoA { SUMA, RESTA, MULTIPLICACION, DIVISION}

        TipoA tipoA;
        private NodoAST left;
        private NodoAST right;
        public Aritmetica(int fila, int columna, TipoA tipoA, NodoAST left, NodoAST right): base(fila, columna)
        {
            this.tipoA = tipoA;
            this.left = left;
            this.right = right;
        }
        public override Objeto ejecutar()
        {
            Objeto res_left = this.left.ejecutar(); //5
            Objeto res_right = this.right.ejecutar();   //5


            if (this.tipoA == TipoA.SUMA)
            {
                return new Primitivo(Objeto.Tipo.INTEGER, Int16.Parse(res_left.getValue().ToString()) + Int16.Parse(res_right.getValue().ToString()));
            }else if (this.tipoA == TipoA.RESTA)
            {
                return new Primitivo(Objeto.Tipo.INTEGER, Int16.Parse(res_left.getValue().ToString()) - Int16.Parse(res_right.getValue().ToString()));
            }
            else if (this.tipoA == TipoA.MULTIPLICACION)
            {
                return new Primitivo(Objeto.Tipo.INTEGER, Int16.Parse(res_left.getValue().ToString()) * Int16.Parse(res_right.getValue().ToString()));
            }
            else if (this.tipoA == TipoA.DIVISION)
            {
                return new Primitivo(Objeto.Tipo.INTEGER, Int16.Parse(res_left.getValue().ToString()) / Int16.Parse(res_right.getValue().ToString()));
            }
            else
            {
                return null;
            }
        }
    }
}
