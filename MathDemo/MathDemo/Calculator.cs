namespace MathDemo
{
    public class Calculator
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public int Result { get; set; }

        public int Add()
        {
            return Operand1 + Operand2;
        }
    }
}