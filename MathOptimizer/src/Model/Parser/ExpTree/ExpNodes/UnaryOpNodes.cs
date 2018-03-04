using System;

namespace MathOptimizer.Model.Parser.ExpTree
{
    /// <summary>
    /// Base class for unary math operations nodes
    /// </summary>
    abstract class UnaryOpNode : ExpNode
    {
        public UnaryOpNode(ExpNode operand)
        {
            m_operand = operand;
        }
    
        protected ExpNode m_operand;
    }

    /* Operations */

    class UnaryMinusNode : UnaryOpNode
    {
        public UnaryMinusNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return -m_operand.Evaluate(values);
        }
    }

    class SinNode : UnaryOpNode
    {
        public SinNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Sin(m_operand.Evaluate(values));
        }
    }

    class CosNode : UnaryOpNode
    {
        public CosNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Cos(m_operand.Evaluate(values));
        }
    }

    class TgNode : UnaryOpNode
    {
        public TgNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Tan(m_operand.Evaluate(values));
        }
    }

    class CtgNode : UnaryOpNode
    {
        public CtgNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return 1.0 / Math.Tan(m_operand.Evaluate(values));
        }
    }

    class ArcsinNode : UnaryOpNode
    {
        public ArcsinNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Asin(m_operand.Evaluate(values));
        }
    }

    class ArccosNode : UnaryOpNode
    {
        public ArccosNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Acos(m_operand.Evaluate(values));
        }
    }

    class ArctgNode : UnaryOpNode
    {
        public ArctgNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Atan(m_operand.Evaluate(values));
        }
    }

    class ArcctgNode : UnaryOpNode
    {
        public ArcctgNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return 1.0 / Math.Atan(m_operand.Evaluate(values));
        }
    }

    class SqrtNode : UnaryOpNode
    {
        public SqrtNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            double redicand = m_operand.Evaluate(values);

            if (redicand < 0)
            {
                throw new ArgumentException("Negative redicand");
            }

            return Math.Sqrt(redicand);
        }
    }

    class ExNode : UnaryOpNode
    {
        public ExNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Exp(m_operand.Evaluate(values));
        }
    }

    class LnNode : UnaryOpNode
    {
        public LnNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            double exp = m_operand.Evaluate(values);

            if (exp == 0)
            {
                throw new ArgumentException("Null logarithm argument");
            }

            return Math.Log(exp);
        }
    }

    class AbsNode : UnaryOpNode
    {
        public AbsNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Abs(m_operand.Evaluate(values));
        }
    }

    class SignNode : UnaryOpNode
    {
        public SignNode(ExpNode operand)
            : base(operand)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Sign(m_operand.Evaluate(values));
        }
    }
}
