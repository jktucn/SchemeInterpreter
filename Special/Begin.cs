// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printBegin(t, n, p);
        }

        public override Node eval(Node exp, Environment env)
        {
            int length = Util.expLength(exp);
            
            if (length < 2)
            {
                Console.Error.WriteLine("Error: invalid expression");
                return Nil.getInstance();
            }

            return evalBody(exp.getCdr(), env);
        }

        public static Node evalBody(Node exp, Environment env)
        {
            Node result = exp.getCar().eval(env);
            if (exp.getCdr().isNull())
            {
                return result;
            }
            return evalBody(exp.getCdr(), env);
        }
    }
}

