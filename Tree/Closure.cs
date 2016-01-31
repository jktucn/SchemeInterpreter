// Closure.java -- the data structure for function closures

// Class Closure is used to represent the value of lambda expressions.
// It consists of the lambda expression itself, together with the
// environment in which the lambda expression was evaluated.

// The method apply() takes the environment out of the closure,
// adds a new frame for the function call, defines bindings for the
// parameters with the argument values in the new frame, and evaluates
// the function body.

using System;

namespace Tree
{
    public class Closure : Node
    {
        private Node fun;		// a lambda expression
        private Environment env;	// the environment in which
                                        // the function was defined

        public Closure(Node f, Environment e)	{ fun = f;  env = e; }

        public Node getFun()		{ return fun; }
        public Environment getEnv()	{ return env; }

        // TODO: The method isProcedure() should be defined in
        // class Node to return false.
        // finished
        public override bool isProcedure()	{ return true; }

        public override void print(int n) {
            // there got to be a more efficient way to print n spaces
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.WriteLine("#{Procedure");
            if (fun != null)
                fun.print(Math.Abs(n) + 4);
            for (int i = 0; i < Math.Abs(n); i++)
                Console.Write(' ');
            Console.WriteLine('}');
        }

        // TODO: The method apply() should be defined in class Node
        // to report an error.  It should be overridden only in classes
        // BuiltIn and Closure.
        public override Node apply (Node args)
        {
            Node param = fun.getCdr().getCar();
            int numArgs = Util.expLength(args);
            int numParam = Util.expLength(param);
            if (numArgs != numParam)
            {
                Console.Error.WriteLine("Error: wrong number of arguments");
            }
            Environment env1 = new Environment(env);
            while (param.isPair() && args.isPair())
            {
                Node id = param.getCar();
                Node val = args.getCar();
                env1.define(id, val);
                param = param.getCdr();
                args = args.getCdr();
            }
            while (param.isPair())
            {
                Node id = param.getCar();
                Node val = Nil.getInstance();
                env1.define(id, val);
                param = param.getCdr();
            }
            Node exp1 = fun.getCdr().getCdr();
            return Begin.evalBody(exp1, env1);
        }

    }    
}
