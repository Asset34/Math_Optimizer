using System;

namespace MathOptimizer.Parser.ExpTree
{
    /// <summary>
    /// Base class for binary math operations nodes
    /// </summary>
    abstract class BinaryOpNode : ExpNode
    {
        public BinaryOpNode(ExpNode operand1, ExpNode operand2)
        {
            m_operand1 = operand1;
            m_operand2 = operand2;
        }

        protected ExpNode m_operand1;
        protected ExpNode m_operand2;
    }

    /* Operations */

    class PlusNode : BinaryOpNode
    {
        public PlusNode(ExpNode operand1, ExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            return m_operand1.Evaluate(values) + m_operand2.Evaluate(values);
        }
    }

    class MinusNode : BinaryOpNode
    {
        public MinusNode(ExpNode operand1, ExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            return m_operand1.Evaluate(values) - m_operand2.Evaluate(values);
        }
    }

    class MultyNode : BinaryOpNode
    {
        public MultyNode(ExpNode operand1, ExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            return m_operand1.Evaluate(values) * m_operand2.Evaluate(values);
        }
    }

    class DivisionNode : BinaryOpNode
    {
        public DivisionNode(ExpNode operand1, ExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            double denominator = m_operand2.Evaluate(values);

            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }

            return m_operand1.Evaluate(values) / denominator;
        }
    }

    class PowerNode : BinaryOpNode
    {
        public PowerNode(ExpNode operand1, ExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Pow(m_operand1.Evaluate(values), m_operand2.Evaluate(values));
        }
    }

    class LogNode : BinaryOpNode
    {
        public LogNode(ExpNode operand1, ExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            double exp = m_operand2.Evaluate(values);

            if (exp == 0)
            {
                throw new ArgumentException("Null logarithm argument");
            }

            return Math.Log(m_operand1.Evaluate(values), exp);
        }
    }

    class MinNode : BinaryOpNode
    {
        public MinNode(ExpNode operand1, ExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Min(m_operand1.Evaluate(values), m_operand2.Evaluate(values));
        }
    }

    class MaxNode : BinaryOpNode
    {
        public MaxNode(ExpNode operand1, ExpNode operand2)
            : base(operand1, operand2)
        {
        }
        public override double Evaluate(Values values)
        {
            return Math.Max(m_operand1.Evaluate(values), m_operand2.Evaluate(values));
        }
    }
}
