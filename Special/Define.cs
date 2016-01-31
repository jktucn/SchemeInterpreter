// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printDefine(t, n, p);
        }

        public override Node eval(Node exp, Environment env)
        {
            int length = Util.expLength(exp);
            if (length < 3)
            {
                Console.Error.WriteLine("Error: invalid expression");
                return Nil.getInstance();
            }
            Node second = exp.getCdr().getCar();
            Node name, value;
            if (length == 3 && second.isSymbol())
            {
                name = second;
                value = exp.getCdr().getCdr().getCar().eval(env);
                env.define(name, value);
                return null;
            }
            if (!second.isPair())
            {
                Console.Error.WriteLine("Error: invalid expression");
                return Nil.getInstance();
            }
            name = second.getCar();
            Node lambda = exp.getCdr();
            lambda.setCar(second.getCdr());
            lambda = new Cons(new Ident("lambda"), lambda);
            value = lambda.eval(env);
            env.define(name, value);

            return null;
        }


    }
}


