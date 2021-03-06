﻿using System;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;
using System.IO;
using System.Threading.Tasks;
using Proyecto1.Analisis;
using Proyecto1.Instrucciones;

namespace Proyecto1.Administracion
{
    public sealed class MasterClass
    {

        private string output = "";
        private string mensajes = "";
        private LinkedList<NodoAST> instrucciones = new LinkedList<NodoAST>();
        private LinkedList<Error> errores = new LinkedList<Error>();
        private Dictionary<string, Funcion> funciones =new Dictionary<string, Funcion>();   //aqui guardo mis funciones


        private static readonly MasterClass instance = new MasterClass();

        private string grafo = "";   //aqui voy a ir guardando todo el codigo en dot
        private int contador = 0;     //identificador incrementable de cada nodo

        static MasterClass() { }
        private MasterClass() { }
        public static MasterClass Instance
        {
            get
            {
                return instance;
            }
        }

        public void addError(Error error)
        {
            this.errores.AddLast(error);
        }

        public Dictionary<string, Funcion> getFunciones()
        {
            return this.funciones;
        }

        public LinkedList<Error> getErrores()
        {
            return this.errores;
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
            this.grafo = "";
            this.contador = 0;
            this.errores = new LinkedList<Error>();
            this.funciones = new Dictionary<string, Funcion>();
            this.agregarNativas();  //agregamos las funciones nativas...
        }

        public void addInstruction(NodoAST nodo)
        {
            this.instrucciones.AddLast(nodo);
        }

        public int getCantidad()
        {
            return this.instrucciones.Count;
        }




        /*
         * SECCIÓN DE GENERACIÓN DE CODIGO .dot
         * 
         * Ejemplo
         * 
         * digraph G {
         *  nodo0[label="etiqueta"];
         *  nodo1[label="hijo1"];
         *  nodo2[label="hijo2"];
         *  nodo0 -> nodo1;
         * }
         * **/





        private void getDot(ParseTreeNode raiz)
        {
            grafo = "digraph G {";
            grafo += "nodo0[label=\"" + raiz.ToString() + "\"];\n";
            contador = 1;
            recorrerAST("nodo0", raiz);
            grafo += "}";
        }

        private  void recorrerAST(String padre, ParseTreeNode hijos)
        {
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                string nombreHijo = "nodo" + contador.ToString();
                grafo += nombreHijo + "[label=\"" + hijo.ToString() + "\"];\n";
                grafo += padre + "->" + nombreHijo + ";\n";
                contador++;
                recorrerAST(nombreHijo, hijo);
            }
        }

        public  async Task generarImagen(ParseTreeNode raiz)
        {
            this.getDot(raiz);
            //DOT dot = new DOT();
            //BinaryImage img = dot.ToPNG(this.grafo);
            //img.Save("C:\\compiladores2\\AST.png");
            await File.WriteAllTextAsync("C:\\compiladores2\\AST.txt", this.grafo);
        }


        /* 
         * Sirve para ejecutar cada instruccion recibida
         * **/
        public void ejecutar()
        {
            if (this.errores.Count > 0)
            {
                foreach(Error e in errores)
                {
                    this.addOutput(e.getDescripcion()+ "-> ln: "+e.getLinea()+", col: "+e.getColumna());
                }
            }
            else
            {
                foreach (NodoAST nodo in instrucciones)
                {
                    nodo.ejecutar();
                }
            }
            
        }

        public bool addFunction(Funcion tmp)
        {
            string name = tmp.getNombre().ToLower();
            if (!this.funciones.ContainsKey(name))
            {
                //significa que ya hay una bajo ese nombre!
                this.funciones.Add(name,tmp);
                return true;
            }
            return false;

        }

        public Funcion getFuncion(string id)
        {
            string name = id.ToLower();
            if (this.funciones.ContainsKey(name))
            {
                //significa que ya hay una bajo ese nombre!
                Funcion val;
                this.funciones.TryGetValue(name, out val);
                return val;

            }
            return null;
        }


        private void agregarNativas()
        {
            LinkedList<NodoAST> nativas = new LinkedList<NodoAST>();

            nativas.AddLast(new Writeln(0, 0)); //agrego la función nativa Writeln


            foreach(NodoAST tmp in nativas)
            {
                tmp.ejecutar(); //al ejecutarlas, las agregamos a la lista de funciones :)
            }
        }
    }
}
