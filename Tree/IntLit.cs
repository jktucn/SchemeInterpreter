// IntLit -- Parse tree node class for representing integer literals

using System;

namespace Tree
{
    public class IntLit : Node
    {
        private int intVal;

        public IntLit(int i)
        {
            intVal = i;
        }

        public override void print(int n)
        {
            Printer.printIntLit(n, intVal);
        }

        public override bool isNumber()
        {
            return true;
        }

        //added here and down
        public int getIntVal()
        {
            return intVal;
        }

        public override Node eval(Environment env)
        {
            return this;
        }
    }
}
