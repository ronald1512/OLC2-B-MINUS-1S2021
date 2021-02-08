using System;
using System.Collections.Generic;
using System.Text;
using Irony.Ast;        //Agregar esta referencia. Es para poder usar estas clases de Irony
using Irony.Parsing;    //Agregar esta referencia. Es para poder usar estas clases de Irony

namespace Proyecto1.Analisis
{
    /* Clase para la definición de la gramática
     * 
     * **/
    class Gramatica: Grammar    //Esta la reconoce con los using que agregamos
    {
        public Gramatica(): base(caseSensitive: true)  //le agregamos la propiedad de case sensitive. 
        {
            //Sugerencia 1: Uso de regiones. Sirven para mantener ordenado el código
            #region ER
            RegexBasedTerminal numero = new RegexBasedTerminal("numero", "[0-9]+"); // el primer parámetro es el nombre y el segundo le er.
            CommentTerminal comentario = new CommentTerminal("comentario", "//", "\n", "\r\n"); //si viene una nueva linea se termina de reconocer el comentario.
            #endregion

            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var div = ToTerm("/");
            var writeln = ToTerm("writeln");
            var ptcoma = ToTerm(";");

            RegisterOperators(1, Associativity.Left, mas, menos);
            RegisterOperators(2, Associativity.Left, por, div);
            #endregion

            #region No terminales
            NonTerminal S = new NonTerminal("S");
            NonTerminal E = new NonTerminal("E");
            NonTerminal INSTRUCTION_LIST = new NonTerminal("Instruccion_list");
            NonTerminal INSTRUCTION = new NonTerminal("Instruccion");
               
            NonGrammarTerminals.Add(comentario);    //Le decimos que es un terminal no gramatical. No se toma en cuenta en la sintaxis
            #endregion

            #region Gramática
            //Irony soporta gramáticas ambiguas y no ambiguas
            S.Rule = INSTRUCTION_LIST;

            INSTRUCTION_LIST.Rule = INSTRUCTION_LIST + INSTRUCTION + ptcoma
                | INSTRUCTION + ptcoma
                ;

            INSTRUCTION.Rule = writeln + ToTerm("(") + E + ToTerm(")");


            E.Rule = E + mas + E
                | E + menos + E
                | E + por + E
                | E + div + E
                | numero
                ;
            #endregion

            #region Preferencias
            //No terminal inicial:
            this.Root = S;
            //this.MarkTransient(INSTRUCTION);
            #endregion
        }
    }
}
