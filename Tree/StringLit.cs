// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree
{
    public class StringLit : Node
    {
        public static bool writeMode = true;
        private string stringVal;

        public StringLit(string s)
        {
            stringVal = s;
        }

        public override void print(int n)
        {
            if (writeMode)
            {
                Printer.printStringLit(n, stringVal);
            }
            else
            {
                Console.Out.Write(stringVal);
            }
        }

        public override bool isString()
        {
            return true;
        }

        //added this and down
        public override Node eval(Environment env)
        {
            return this;
        }

        public string getStringVal()
        {
            return this.stringVal;
        }
    }
}

