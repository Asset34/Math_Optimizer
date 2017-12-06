using System;

namespace MathOptimizer.Parser.Func.Tree
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
        public override ExpNode DeepClone()
        {
            return new PlusExp(operand1.DeepClone(), operand2.DeepClone());
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
        public override ExpNode DeepClone()
        {
            return new MinusExp(operand1.DeepClone(), operand2.DeepClone());
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
        public override ExpNode DeepClone()
        {
            return new MultyExp(operand1.DeepClone(), operand2.DeepClone());
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
        public override ExpNode DeepClone()
        {
            return new DivisionExp(operand1.DeepClone(), operand2.DeepClone());
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
        public override ExpNode DeepClone()
        {
            return new PowerExp(operand1.DeepClone(), operand2.DeepClone());
        }

        private ExpNode operand1;
        private ExpNode operand2;
    }
    class IndexingExp : ExpNode
    {
        public IndexingExp(ExpNode operand1, ExpNode operand2)
        {
            VariableExp temp = operand1 as VariableExp;

            if (temp == null)
            {
                throw new ArgumentException("Indexing of non-variable token");
            }

            this.variable = temp;
            this.indexExp = operand2;
        }
        public override double Evaluate(Values values)
        {
            // Integer check of index
            double value = indexExp.Evaluate(values);
            int index;

            bool testInt = int.TryParse(value.ToString(), out index);
            if (!testInt)
            {
                throw new ArgumentException("Non-integer index");
            }

            // Variable creation
            VariableExp newVariable = new VariableExp(variable.Name + index.ToString());

            return newVariable.Evaluate(values);
        }
        public override ExpNode DeepClone()
        {
            return new IndexingExp(variable.DeepClone(), indexExp.DeepClone());
        }

        private VariableExp variable;
        private ExpNode indexExp;
    }

    /* Unary operations */
    class UnaryMinusExp : ExpNode
    {
        public UnaryMinusExp(ExpNode operand)
        {
            this.operand = operand;
        }
        public override double Evaluate(Values values)
        {
            return -operand.Evaluate(values);
        }
        public override ExpNode DeepClone()
        {
            return new UnaryMinusExp(operand.DeepClone());
        }

        private ExpNode operand;
    }

    /* Functions */
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
        public override ExpNode DeepClone()
        {
            return new SinExp(operand.DeepClone());
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
        public override ExpNode DeepClone()
        {
            return new CosExp(operand.DeepClone());
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
        public override ExpNode DeepClone()
        {
            return new TgExp(operand.DeepClone());
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
        public override ExpNode DeepClone()
        {
            return new CtgExp(operand.DeepClone());
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
        public override ExpNode DeepClone()
        {
            return new SqrtExp(operand.DeepClone());
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
        public override ExpNode DeepClone()
        {
            return new ExponentExp(operand.DeepClone());
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
        public override ExpNode DeepClone()
        {
            return new LnExp(operand.DeepClone());
        }

        private ExpNode operand;
    }
}
