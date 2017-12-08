using System;

namespace MathOptimizer.Func.Tree
{
    /* Abstract operations */
    abstract class UnaryOperation : IExpNode
    {
        public UnaryOperation(IExpNode operand)
        {
            this.operand = operand;
        }
        public abstract double Evaluate(Values values);

        protected IExpNode operand;
    }
    abstract class BinaryOperation : IExpNode
    {
        public BinaryOperation(IExpNode operand1, IExpNode operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public abstract double Evaluate(Values values);

        protected IExpNode operand1;
        protected IExpNode operand2;
    }

    /* Binary operations */
    class PlusExp : BinaryOperation
    {
        public PlusExp(IExpNode operand1, IExpNode operand2)
            :base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) + operand2.Evaluate(values);
        }
    }
    class MinusExp : BinaryOperation
    {
        public MinusExp(IExpNode operand1, IExpNode operand2)
            :base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) - operand2.Evaluate(values);
        }
    }
    class MultyExp : BinaryOperation
    {
        public MultyExp(IExpNode operand1, IExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            return operand1.Evaluate(values) * operand2.Evaluate(values);
        }
    }
    class DivisionExp : BinaryOperation
    {
        public DivisionExp(IExpNode operand1, IExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            double denominator = operand2.Evaluate(values);

            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            
            return operand1.Evaluate(values) / denominator;
        }
    }
    class PowerExp : BinaryOperation
    {
        public PowerExp(IExpNode operand1, IExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Pow(operand1.Evaluate(values), operand2.Evaluate(values));
        }
    }

    /* Unary operations */
    class UnaryMinusExp : UnaryOperation
    {
        public UnaryMinusExp(IExpNode operand)
            :base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return -operand.Evaluate(values);
        }
    }

    /* Unary Functions */
    class SinExp : UnaryOperation
    {
        public SinExp(IExpNode operand)
            :base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Sin(operand.Evaluate(values));
        }
    }
    class CosExp : UnaryOperation
    {
        public CosExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Cos(operand.Evaluate(values));
        }
    }
    class TgExp : UnaryOperation
    {
        public TgExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Tan(operand.Evaluate(values));
        }
    }
    class CtgExp : UnaryOperation
    {
        public CtgExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return 1.0 / Math.Tan(operand.Evaluate(values));
        }
    }
    class ArcSinExp : UnaryOperation
    {
        public ArcSinExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Asin(operand.Evaluate(values));
        }
    }
    class ArcCosExp : UnaryOperation
    {
        public ArcCosExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Acos(operand.Evaluate(values));
        }
    }
    class ArcTgExp : UnaryOperation
    {
        public ArcTgExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Atan(operand.Evaluate(values));
        }
    }
    class ArcCtgExp : UnaryOperation
    {
        public ArcCtgExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return 1.0 / Math.Atan(operand.Evaluate(values));
        }
    }
    class SqrtExp : UnaryOperation
    {
        public SqrtExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            double redicand = operand.Evaluate(values);

            if (redicand < 0)
            {
                throw new ArgumentException("Negative redicand");
            }

            return Math.Sqrt(redicand);
        }
    }
    class ExponentExp : UnaryOperation
    {
        public ExponentExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Exp(operand.Evaluate(values));
        }
    }
    class LnExp : UnaryOperation
    {
        public LnExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            double exp = operand.Evaluate(values);

            if (exp == 0)
            {
                throw new ArgumentException("Null logarithm argument");
            }

            return Math.Log(exp);
        }
    }
    class AbsExp : UnaryOperation
    {
        public AbsExp(IExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Abs(operand.Evaluate(values));
        }
    }

    /* Binary Functions */
    class LogExp : BinaryOperation
    {
        public LogExp(IExpNode operand1, IExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            double exp = operand2.Evaluate(values);

            if (exp == 0)
            {
                throw new ArgumentException("Null logarithm argument");
            }

            return Math.Log(operand1.Evaluate(values), exp);
        }
    }
}
