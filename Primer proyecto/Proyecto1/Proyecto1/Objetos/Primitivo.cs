using System;
using System.Collections.Generic;
using System.Text;
using Proyecto1.Administracion;

namespace Proyecto1.Objetos
{
    public class Primitivo : Objeto
    {
        public object valor;    //3, 4,... true, false, ..., 2.3 
        public Primitivo(Tipo tipo, object valor): base(tipo)
        {
            this.valor = valor;
        }

        public override object getValue()
        {
            return this.valor;
        }

        public override string toString()
        {
            return this.valor.ToString();
        }
    }
}
