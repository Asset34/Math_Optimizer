namespace MathOptimizer.Methods.Params
{
    struct InputParameters
    {
        public Interval StartInterval { get; set; }
        public Vector StartVecPoint   { get; set; }
        public double StartPoint      { get; set; }
        public double StepValue       { get; set; }
        public double StepCoefficient { get; set; }
        public double Eps             { get; set; }
        public int IterationLimit     { get; set; } 
    }
}
