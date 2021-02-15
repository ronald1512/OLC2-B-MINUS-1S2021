using System;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;

namespace Proyecto1.Administracion
{
    class Dot
    {
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
        private static string grafo = "";   //aqui voy a ir guardando todo el codigo en dot
        private static int contador = 0;     //identificador incrementable de cada nodo

        public static string getDot(ParseTreeNode raiz)
        {
            grafo = "digraph G {";
            grafo += "nodo0[label=\"" + raiz.ToString() + "\"];\n";
            contador = 1;

            grafo += "}";
            return grafo;
        }

        public static void recorrerAST(String padre, ParseTreeNode hijos)
        {
            foreach(ParseTreeNode hijo in hijos.ChildNodes)
            {
                string nombreHijo = "nodo" + contador.ToString();
                grafo += nombreHijo + "[label=\"" + hijo.ToString() + "\"];\n";
                grafo += padre + "->" + nombreHijo + ";\n";
                contador++;
                recorrerAST(nombreHijo, hijo);
            }
        }
    }
}
