// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printIf(t, n, p);
        }

        public override Node eval(Node exp, Environment env)
        {
            int length = Util.expLength(exp);
            if (length < 3 || length >4)
            {
                Console.Error.WriteLine("Error: invalid expression");
                return Nil.getInstance();
            }
            Node cond = exp.getCdr().getCar();
            Node then = exp.getCdr().getCdr().getCar();
            if (cond.eval(env) != BoolLit.getInstance(false))
            {
                return then.eval(env);
            }
            else if (length == 4)
            {
                Node el = exp.getCdr().getCdr().getCdr().getCar();
                return el.eval(env);
            }
            Console.Error.WriteLine("Error: invalid expression");
            return Nil.getInstance();
        }
    }
}

