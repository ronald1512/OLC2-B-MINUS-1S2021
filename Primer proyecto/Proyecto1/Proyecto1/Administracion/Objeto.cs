using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1.Administracion
{
    public abstract class Objeto
    {
        public enum Tipo
        {
            INTEGER,
            BOOLEAN,
            ARRAY
        }

        public Tipo tipo;

        public Objeto(Tipo tipo)
        {
            this.tipo = tipo;
        }

        public abstract string toString();
        public abstract object getValue();


    }
}
