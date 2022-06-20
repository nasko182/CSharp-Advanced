using System;
using System.Linq;

namespace ListyIteratorNMS
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            string command;
                var iterator = new ListyIterator<string>();
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                if (action == "Create")
                {
                    if (cmdArgs.Length>1)
                    {
                        iterator.Create(cmdArgs.Skip(1).ToArray());
                    }
                    else
                    {
                        iterator.Create(new string[1] {null});
                    }
                }
                else if(action == "Move")
                {
                    iterator.Move();
                }
                else if (action=="Print")
                {
                    iterator.Print();
                }
                else if (action == "HasNext")
                {
                    iterator.HasNext();
                }
                else if (action== "PrintAll")
                {
                    iterator.PrintAll();
                }
            }
        }
    }
}
