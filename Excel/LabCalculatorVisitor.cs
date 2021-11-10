using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel
{
    class RecursiveException : Exception
    {
    }
    class DivideZeroException : Exception
    {
    }
    class LabCalculatorVisitor : LabCalculatorBaseVisitor<double>
    {
        //Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();
        public Dictionary<string, Cell> tableIdentifier;
        public string CurrentCell;

        public LabCalculatorVisitor(Dictionary<string, Cell> dictionary, string cell)
        {
            tableIdentifier = dictionary;
            CurrentCell = cell;
        }

        public override double VisitCompileUnit(LabCalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(LabCalculatorParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);

            return result;
        }

        //IdentifierExpr
        public override double VisitIdentifierExpr(LabCalculatorParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            if (!Recursive(CurrentCell, result))
            {
                if (!tableIdentifier[CurrentCell].CellReference.Contains(result))
                    tableIdentifier[CurrentCell].CellReference.Add(result);
                string StrValue = tableIdentifier[result].Val;
                if (StrValue == "Error")
                    throw new Exception();
                if (StrValue == "ErrorCycle")
                    throw new RecursiveException();
                if (StrValue == "ErrorDivZero")
                    throw new DivideByZeroException();
                double value = Convert.ToDouble(StrValue);
                Debug.WriteLine(value);
                return value;
            }
            else
            {
                throw new RecursiveException();
            }
        }

        public bool Recursive(string CurrentCell, string ReferedCell)
        {
            if (ReferedCell == CurrentCell)
                return true;
            else if (tableIdentifier[ReferedCell].CellReference.Count != 0)
            {
                foreach (string i in tableIdentifier[ReferedCell].CellReference)
                {
                    if (Recursive(CurrentCell, i)) return true;
                }
                return false;
            }
            else return false;
        }

        // our "( )"
        public override double VisitParenthesizedExpr(LabCalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        // our "^" operator
        public override double VisitExponentialExpr(LabCalculatorParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            Debug.WriteLine("{0} ^ {1}", left, right);
            return System.Math.Pow(left, right);
        }

        private double WalkLeft(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(0));
        }

        private double WalkRight(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(1));
        }

        // our binary "+ -" operators
        public override double VisitAdditiveExpr(LabCalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.ADD)
            {
                Debug.WriteLine("{0} + {1}", left, right);
                return left + right;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine("{0} - {1}", left, right);
                return left - right;
            }
        }

        // our unary operators "+ -"
        public override double VisitUnaryAdditiveExpr(LabCalculatorParser.UnaryAdditiveExprContext context)
        {
            var expression = Visit(context.expression());
            if (context.operatorToken.Type == LabCalculatorLexer.ADD)
            {
                Debug.WriteLine("+{0}", expression);
                return expression;
            }
            else
            {
                Debug.WriteLine("-{0}", expression);
                return -expression;
            }
        }

        // our binary "* /" operators
        public override double VisitMultiplicativeExpr(LabCalculatorParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.MULTIPLY)
            {
                Debug.WriteLine("{0} * {1}", left, right);
                return left * right;
            }
            else //LabCalculatorLexer.DIVIDE
            {
                Debug.WriteLine("{0} / {1}", left, right);
                if(right == 0)
                    throw new DivideByZeroException();
                return left / right;
            }
        }
        // our "% /" operators
        public override double VisitModDivExpr(LabCalculatorParser.ModDivExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.MOD)
            {
                Debug.WriteLine("{0} % {1}", left, right);
                return left % right;
            }
            else //LabCalculatorLexer.DIV Integer division
            {
                Debug.WriteLine("{0} / {1}", left, right);
                return (int)(left / right);
            }
        }
    }
}