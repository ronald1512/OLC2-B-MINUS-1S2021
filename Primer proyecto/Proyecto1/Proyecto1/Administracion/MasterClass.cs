using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1.Administracion
{
    public sealed class MasterClass
    {

        private string output = "";
        private string mensajes = "";
        private LinkedList<NodoAST> instrucciones = new LinkedList<NodoAST>();
        private static readonly MasterClass instance = new MasterClass();

        static MasterClass() { }
        private MasterClass() { }
        public static MasterClass Instance
        {
            get
            {
                return instance;
            }
        }

        public void addMessage(string mensaje)
        {
            this.mensajes += "\n" + mensaje;
        }
        public string getMessages()
        {
            return this.mensajes;
        }

        public void addOutput(string mensaje)
        {
            this.output += "\n" + mensaje;
        }
        public string getOutput()
        {
            return this.output;
        }

        public void clear()
        {
            this.output = "";
            this.mensajes = "";
            this.instrucciones = new LinkedList<NodoAST>();
        }

        public void addInstruction(NodoAST nodo)
        {
            this.instrucciones.AddLast(nodo);
        }

        public int getCantidad()
        {
            return this.instrucciones.Count;
        }

        public void ejecutar()
        {
            foreach(NodoAST nodo in instrucciones)
            {
                nodo.ejecutar();
            }
        }
    }
}
