// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printLet(t, n, p);
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
            while (second.isPair())
            {
                if (Util.expLength(second.getCar()) != 2)
                {
                    Console.Error.WriteLine("Error: invalid expression");
                    return Nil.getInstance();
                }
                second = second.getCdr();
            }
            second = exp.getCdr().getCar();
            Environment env1 = new Environment(env);
            while (second.isPair())
            {
                Node id = second.getCar().getCar();
                Node val = second.getCar().getCdr().getCar();
                env1.define(id, val);
                second = second.getCdr();
            }
            Node exp1 = exp.getCdr().getCdr();
            return Begin.evalBody(exp1, env1);
        }
    }
}


