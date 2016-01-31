// SPP -- The main program of the Scheme pretty printer.

using System;
using Parse;
using Tokens;
using Tree;


public class Scheme4101
{
    public static Tree.Environment env;
    public static Parser parser;
    public static int Main(string[] args)
    {
        // Create scanner that reads from standard input
        Scanner scanner = new Scanner(Console.In);
        
        if (args.Length > 1 ||
            (args.Length == 1 && ! args[0].Equals("-d")))
        {
            Console.Error.WriteLine("Usage: mono SPP [-d]");
            return 1;
        }
        
        // If command line option -d is provided, debug the scanner.
        if (args.Length == 1 && args[0].Equals("-d"))
        {
            // Console.Write("Scheme 4101> ");
            Token tok = scanner.getNextToken();
            while (tok != null)
            {
                TokenType tt = tok.getType();

                Console.Write(tt);
                if (tt == TokenType.INT)
                    Console.WriteLine(", intVal = " + tok.getIntVal());
                else if (tt == TokenType.STRING)
                    Console.WriteLine(", stringVal = " + tok.getStringVal());
                else if (tt == TokenType.IDENT)
                    Console.WriteLine(", name = " + tok.getName());
                else
                    Console.WriteLine();

                // Console.Write("Scheme 4101> ");
                tok = scanner.getNextToken();
            }
            return 0;
        }

        // Create parser
        TreeBuilder builder = new TreeBuilder();
        parser = new Parser(scanner, builder);
        Node root;

        // TODO: Create and populate the built-in environment and
        // create the top-level environment

        // Read-eval-print loop

        // TODO: print prompt and evaluate the expression
        string[] buildIn = new string[]
        {
            "symbol?",
            "number?",
            "b+",
            "b-",
            "b*",
            "b/",
            "b=",
            "b<",
            "car",
            "cdr",
            "cons",
            "set-car!",
            "set-cdr!",
            "null?",
            "pair?",
            "eq?",
            "procedure?",
            "read",
            "write",
            "display",
            "newline",
            "eval",
            "apply",
            "interaction-environment",
            "load"
        };
        env = new Tree.Environment();
        for (int i = 0; i < buildIn.Length; i++)
        {
            Ident id = new Ident(buildIn[i]);
            env.define(id, new BuiltIn(id));
        }
        env = new Tree.Environment(env);
        Console.Out.Write("> ");
        root = (Node) parser.parseExp();
        while (root != null) 
        {
            
            Node result = root.eval(env);
            if (result != null)
            {
                result.print(0);
            }
            //root.eval(env).print(0);
            Console.Out.Write("> ");
            root = (Node) parser.parseExp();
        }

        return 0;
    }
}
