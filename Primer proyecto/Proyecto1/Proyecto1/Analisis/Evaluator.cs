using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Irony.Ast;
using Irony.Parsing;
using Proyecto1.Administracion;
using Proyecto1.Expresiones;
using Proyecto1.Funciones;
using Proyecto1.Instrucciones;
using Proyecto1.Objetos;

namespace Proyecto1.Analisis
{
    class Evaluator
    {
        public Evaluator() { }

        public void analizar(string cadena)
        {
            Gramatica gramatica = new Gramatica(); //instancia de la gramatica
            LanguageData lenguaje = new LanguageData(gramatica); //genera un lenguaje para nuestra gramática. 
            Parser parser = new Parser(lenguaje); //con esto generamos el parser

            ParseTree arbol = parser.Parse(cadena); //generamos el arbol de analisis sintactico
            ParseTreeNode raiz = arbol.Root;        //obtenemos la raiz del arbol, en este caso será 'S'.


            //Manejo de errores

            if(raiz == null)
            {
                //significa que la cadena de entrada contiene errores, por ello no se generó el arbol de analisis sintactico. 
                MasterClass.Instance.addMessage("Entrada incorrecta");

                foreach(Irony.LogMessage a in arbol.ParserMessages)
                {
                    Error tmp = new Error(
                            a.Location.Line+1,a.Location.Column+1, a.Message,Error.Tipo_error.SINTACTICO
                        );
                    MasterClass.Instance.addError(tmp);
                }
            }
            else
            {
                MasterClass.Instance.addMessage("Entrada correcta");
                _ = MasterClass.Instance.generarImagen(raiz);
                evaluateInstructions(raiz.ChildNodes[0]);
            }

        }

        public void evaluateInstructions(ParseTreeNode instructions)
        {
            if (instructions.ChildNodes.Count == 3)
            {
                evaluateInstructions(instructions.ChildNodes[0]);
                evaluateInstruction(instructions.ChildNodes[1]);
            }
            else
            {
                evaluateInstruction(instructions.ChildNodes[0]);
            }
        }
        
        public void evaluateInstruction(ParseTreeNode instruction)
        {
            

            if(instruction.ChildNodes[0].Term.Name== "writeln")
            {
                NodoAST tmp = null;
                tmp = evaluateWriteln(instruction);
                MasterClass.Instance.addInstruction(tmp);
            }
            
        }

        public NodoAST evaluateWriteln(ParseTreeNode node)
        {
            LinkedList<NodoAST> tmp = new LinkedList<NodoAST>();
            tmp.AddLast(evaluateExpression(node.ChildNodes[2]));
            return new FunctionCall(tmp,"writeln", 0,0); ;
        }

        public NodoAST evaluateExpression(ParseTreeNode node)
        {
            if (node.ChildNodes.Count == 3)
            {
                //se trata de una operación
                //MessageBox.Show("Se trata de una operación: " + node.ChildNodes[1].Term.Name);
                if (node.ChildNodes[1].Term.Name == "+")
                {
                    return new Aritmetica(0,0,Aritmetica.TipoA.SUMA, evaluateExpression(node.ChildNodes[0]), evaluateExpression(node.ChildNodes[2]));
                }else if (node.ChildNodes[1].Term.Name == "-")
                {
                    return new Aritmetica(0, 0, Aritmetica.TipoA.RESTA, evaluateExpression(node.ChildNodes[0]), evaluateExpression(node.ChildNodes[2]));
                }
                else if (node.ChildNodes[1].Term.Name == "*")
                {
                    return new Aritmetica(0, 0, Aritmetica.TipoA.MULTIPLICACION, evaluateExpression(node.ChildNodes[0]), evaluateExpression(node.ChildNodes[2]));
                }
                else
                {
                    return new Aritmetica(0, 0, Aritmetica.TipoA.DIVISION, evaluateExpression(node.ChildNodes[0]), evaluateExpression(node.ChildNodes[2]));
                }
            }
            else
            {
                //MessageBox.Show("Se trata de una constante: " + node.ChildNodes[0].Token.ValueString);
                return new Constante(0, 0, new Primitivo(Objeto.Tipo.INTEGER, node.ChildNodes[0].Token.ValueString));
            }
        }
    }
}
