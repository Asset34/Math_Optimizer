using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Parser.Function
{
    /* Binary operations */
    class PlusExp : ExpTree
    {
        public PlusExp(ExpTree operand1, ExpTree operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) + operand2.Evaluate(values);
        }

        private ExpTree operand1;
        private ExpTree operand2;
    }
    class MinusExp : ExpTree
    {
        public MinusExp(ExpTree operand1, ExpTree operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) - operand2.Evaluate(values);
        }

        private ExpTree operand1;
        private ExpTree operand2;
    }
    class MultyExp : ExpTree
    {
        public MultyExp(ExpTree operand1, ExpTree operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) * operand2.Evaluate(values);
        }

        private ExpTree operand1;
        private ExpTree operand2;
    }
    class DivisionExp : ExpTree
    {
        public DivisionExp(ExpTree operand1, ExpTree operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) / operand2.Evaluate(values);
        }

        private ExpTree operand1;
        private ExpTree operand2;
    }
    class PowerExp : ExpTree
    {
        public PowerExp(ExpTree operand1, ExpTree operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override double Evaluate(Values values)
        {
            return Math.Pow(operand1.Evaluate(values), operand2.Evaluate(values));
        }

        private ExpTree operand1;
        private ExpTree operand2;
    }

    /* Unary operations */
    class SinExp : ExpTree
    {
        public SinExp(ExpTree operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Sin(operand.Evaluate(values));
        }

        private ExpTree operand;
    }
    class CosExp : ExpTree
    {
        public CosExp(ExpTree operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Cos(operand.Evaluate(values));
        }

        private ExpTree operand;
    }
    class TgExp : ExpTree
    {
        public TgExp(ExpTree operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Tan(operand.Evaluate(values));
        }

        private ExpTree operand;
    }
    class CtgExp : ExpTree
    {
        public CtgExp(ExpTree operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Atan(operand.Evaluate(values));
        }

        private ExpTree operand;
    }
    class SqrtExp : ExpTree
    {
        public SqrtExp(ExpTree operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Sqrt(operand.Evaluate(values));
        }

        private ExpTree operand;
    }
    class ExponentExp : ExpTree
    {
        public ExponentExp(ExpTree operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Exp(operand.Evaluate(values));
        }

        private ExpTree operand;
    }
    class LnExp : ExpTree
    {
        public LnExp(ExpTree operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return Math.Log(operand.Evaluate(values));
        }

        private ExpTree operand;
    }
}
