// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
	public Cond() { }

        public override void print(Node t, int n, bool p)
        { 
            Printer.printCond(t, n, p);
        }

        public override Node eval(Node exp, Environment env)
        {
            int length = Util.expLength(exp);
            if (length < 2)
            {
                Console.Error.WriteLine("Error: invalid expression");
                return Nil.getInstance();
            }
            Node traverse = exp.getCdr();
            while (traverse.isPair())
            {
                if (!traverse.getCar().isPair())
                {
                    Console.Error.WriteLine("Error: invalid expression");
                    return Nil.getInstance();
                }
                traverse = traverse.getCdr();
            }
            return evalCond(exp.getCdr(), env);
        }

        public static Node evalCond(Node exp, Environment env)
        {
            Node list, test, body;
            while (exp.getCdr().isPair())
            {
                list = exp.getCar();
                test = list.getCar();
                body = list.getCdr();
                // else in the middle
                if (test.isSymbol() && test.getName().Equals("else"))
                {
                    Console.Error.WriteLine("Error: invalid expression");
                    return Nil.getInstance();
                }
                if (test.eval(env) != BoolLit.getInstance(false))
                {
                    if (!body.isNull())
                    {
                        return Begin.evalBody(body, env);
                    }
                    return test;
                }
                exp = exp.getCdr();
            }
            // last test case
            list = exp.getCar();
            test = list.getCar();
            body = list.getCdr();
            if (test.isSymbol() && test.getName().Equals("else"))
            {
                if (!body.isNull())
                {
                    return Begin.evalBody(body, env);
                }
                Console.Error.WriteLine("Error: invalid expression");
                return Nil.getInstance();
            }
            if (test.eval(env) != BoolLit.getInstance(false))
            {
                if (!body.isNull())
                {
                    return Begin.evalBody(body, env);
                }
                return test;
            }
            return Unspecific.getInstance();
        }
    }
}


