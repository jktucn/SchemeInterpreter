// BuiltIn -- the data structure for built-in functions

// Class BuiltIn is used for representing the value of built-in functions
// such as +.  Populate the initial environment with
// (name, new BuiltIn(name)) pairs.

// The object-oriented style for implementing built-in functions would be
// to include the C# methods for implementing a Scheme built-in in the
// BuiltIn object.  This could be done by writing one subclass of class
// BuiltIn for each built-in function and implementing the method apply
// appropriately.  This requires a large number of classes, though.
// Another alternative is to program BuiltIn.apply() in a functional
// style by writing a large if-then-else chain that tests the name of
// the function symbol.

using System;

namespace Tree
{
    public class BuiltIn : Node
    {
        private Node symbol;            // the Ident for the built-in function

        public BuiltIn(Node s)		{ symbol = s; }

        public Node getSymbol()		{ return symbol; }

        // TODO: The method isProcedure() should be defined in
        // class Node to return false.
        // finished
        public override bool isProcedure()	{ return true; }

        public override void print(int n)
        {
            // there got to be a more efficient way to print n spaces
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.Write("#{Built-in Procedure ");
            if (symbol != null)
                symbol.print(-Math.Abs(n));
            Console.Write('}');
            if (n >= 0)
                Console.WriteLine();
        }

        // TODO: The method apply() should be defined in class Node
        // to report an error.  It should be overridden only in classes
        // BuiltIn and Closure.
        public override Node apply (Node args)
        {
            int numArgs = Util.expLength(args);
            if (symbol.getName().Equals("b+"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                if (arg1.isNumber() && arg2.isNumber())
                {
                    return new IntLit( ((IntLit) arg1).getIntVal() + ((IntLit) arg2).getIntVal());
                }
                Console.Error.WriteLine("Error: invalid arguments");
                return Nil.getInstance();
            }

            else if (symbol.getName().Equals("b-"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                if (arg1.isNumber() && arg2.isNumber())
                {
                    return new IntLit(((IntLit)arg1).getIntVal() - ((IntLit)arg2).getIntVal());
                }
                Console.Error.WriteLine("Error: invalid arguments");
                return Nil.getInstance();
            }

            else if (symbol.getName().Equals("b*"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                if (arg1.isNumber() && arg2.isNumber())
                {
                    return new IntLit(((IntLit)arg1).getIntVal() * ((IntLit)arg2).getIntVal());
                }
                Console.Error.WriteLine("Error: invalid arguments");
                return Nil.getInstance();
            }

            else if (symbol.getName().Equals("b/"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                if (arg1.isNumber() && arg2.isNumber())
                {
                    return new IntLit(((IntLit)arg1).getIntVal() / ((IntLit)arg2).getIntVal());
                }
                Console.Error.WriteLine("Error: invalid arguments");
                return Nil.getInstance();
            }

            else if (symbol.getName().Equals("b="))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                if (arg1.isNumber() && arg2.isNumber())
                {
                    return BoolLit.getInstance(((IntLit)arg1).getIntVal() == ((IntLit)arg2).getIntVal());
                }
                Console.Error.WriteLine("Error: invalid arguments");
                return Nil.getInstance();
            }

            else if (symbol.getName().Equals("b<"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                if (arg1.isNumber() && arg2.isNumber())
                {
                    return BoolLit.getInstance(((IntLit)arg1).getIntVal() < ((IntLit)arg2).getIntVal());
                }
                Console.Error.WriteLine("Error: invalid arguments");
                return Nil.getInstance();
            }

            else if (symbol.getName().Equals("number?"))
            {
                if (numArgs != 1)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                return BoolLit.getInstance(arg1.isNumber());
            }

            else if (symbol.getName().Equals("symbol?"))
            {
                if (numArgs != 1)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                return BoolLit.getInstance(arg1.isSymbol());
            }

            else if (symbol.getName().Equals("car"))
            {
                if (numArgs != 1)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node result = arg1.getCar();
                if (result == null)
                {
                    return Nil.getInstance();
                }
                return result;
            }

            else if (symbol.getName().Equals("cdr"))
            {
                if (numArgs != 1)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node result = arg1.getCdr();
                if (result == null)
                {
                    return Nil.getInstance();
                }
                return result;
            }

            else if (symbol.getName().Equals("cons"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                return new Cons(arg1, arg2);
            }

            else if (symbol.getName().Equals("set-car!"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                arg1.setCar(arg2);
                return Unspecific.getInstance();
            }

            else if (symbol.getName().Equals("set-cdr!"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                arg1.setCdr(arg2);
                return Unspecific.getInstance();
            }

            else if (symbol.getName().Equals("null?"))
            {
                if (numArgs != 1)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                return BoolLit.getInstance(arg1.isNull());
            }

            else if (symbol.getName().Equals("pair?"))
            {
                if (numArgs != 1)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                return BoolLit.getInstance(arg1.isPair());
            }

            else if (symbol.getName().Equals("eq?"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                if (arg1.isSymbol() && arg2.isSymbol())
                {
                    return BoolLit.getInstance(((Ident)arg1).getName().Equals(((Ident)arg2).getName()));
                }
                return BoolLit.getInstance(arg1 == arg2);
            }

            else if (symbol.getName().Equals("procedure?"))
            {
                if (numArgs != 1)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                return BoolLit.getInstance(arg1.isProcedure());
            }

            else if (symbol.getName().Equals("read"))
            {
                if (numArgs != 0)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                Node result = (Node) Scheme4101.parser.parseExp();
                if (result != null)
                {
                    return result; 
                }
                return new StringLit("end-of-file");
            }

            else if (symbol.getName().Equals("write"))
            {
                if (numArgs != 1)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                arg1.print(-1);
                return Unspecific.getInstance();
            }

            else if (symbol.getName().Equals("display"))
            {
                if (numArgs != 1)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                StringLit.writeMode = false;
                Node arg1 = args.getCar();
                arg1.print(-1);
                StringLit.writeMode = true;
                return Unspecific.getInstance();
            }

            else if (symbol.getName().Equals("newline"))
            {
                if (numArgs != 0)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                Console.Out.WriteLine();
                return Unspecific.getInstance();
            }

            else if (symbol.getName().Equals("interaction-environment"))
            {
                if (numArgs != 0)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                    return Nil.getInstance();
                }
                return Scheme4101.env;
            }

            else if (symbol.getName().Equals("eval"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                if (arg2.isEnvironment())
                {
                    return arg1.eval((Environment) arg2);
                }
                Console.Error.WriteLine("Error: wrong type of argument");
                return Nil.getInstance();
            }

            else if (symbol.getName().Equals("apply"))
            {
                if (numArgs != 2)
                {
                    Console.Error.WriteLine("Error: wrong number of arguments");
                }
                if (numArgs < 2)
                {
                    return Nil.getInstance();
                }
                Node arg1 = args.getCar();
                Node arg2 = args.getCdr().getCar();
                //if (arg2.isProcedure())
                //{
                    return arg1.apply(arg2);
                //}
                //Console.Error.WriteLine("Error: wrong type of argument");
                //return Nil.getInstance();
            }
            return new StringLit("Error: BuiltIn.apply not yet implemented");
    	}
    }    
}

