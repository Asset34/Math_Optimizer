using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Parser.Function.Tree
{
    /* Binary operations */
    class PlusExp : ExpNode
    {
        public PlusExp(ExpNode operand1, ExpNode operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) + operand2.Evaluate(values);
        }

        private ExpNode operand1;
        private ExpNode operand2;
    }
    class MinusExp : ExpNode
    {
        public MinusExp(ExpNode operand1, ExpNode operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) - operand2.Evaluate(values);
        }

        private ExpNode operand1;
        private ExpNode operand2;
    }
    class MultyExp : ExpNode
    {
        public MultyExp(ExpNode operand1, ExpNode operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) * operand2.Evaluate(values);
        }

        private ExpNode operand1;
        private ExpNode operand2;
    }
    class DivisionExp : ExpNode
    {
        public DivisionExp(ExpNode operand1, ExpNode operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) / operand2.Evaluate(values);
        }

        private ExpNode operand1;
        private ExpNode operand2;
    }
    class PowerExp : ExpNode
    {
        public PowerExp(ExpNode operand1, ExpNode operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override double Evaluate(Values values)
        {
            return Math.Pow(operand1.Evaluate(values), operand2.Evaluate(values));
        }

        private ExpNode operand1;
        private ExpNode operand2;
    }

    /* Unary operations */
    class SinExp : ExpNode
    {
        public SinExp(ExpNode operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Sin(operand.Evaluate(values));
        }

        private ExpNode operand;
    }
    class CosExp : ExpNode
    {
        public CosExp(ExpNode operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Cos(operand.Evaluate(values));
        }

        private ExpNode operand;
    }
    class TgExp : ExpNode
    {
        public TgExp(ExpNode operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Tan(operand.Evaluate(values));
        }

        private ExpNode operand;
    }
    class CtgExp : ExpNode
    {
        public CtgExp(ExpNode operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Atan(operand.Evaluate(values));
        }

        private ExpNode operand;
    }
    class SqrtExp : ExpNode
    {
        public SqrtExp(ExpNode operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Sqrt(operand.Evaluate(values));
        }

        private ExpNode operand;
    }
    class ExponentExp : ExpNode
    {
        public ExponentExp(ExpNode operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Exp(operand.Evaluate(values));
        }

        private ExpNode operand;
    }
    class LnExp : ExpNode
    {
        public LnExp(ExpNode operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Log(operand.Evaluate(values));
        }

        private ExpNode operand;
    }
}
