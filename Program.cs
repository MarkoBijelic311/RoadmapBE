namespace TaskTracer;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("> ");
        var command = Console.ReadLine();

        do{

           if(command == "add")
            {
                //Do something
            }
            else if(command == "update")
            {
                //Do something
            }
            else if(command == "delete")
            {
                //Do something
            }
            else if(command == "list")
            {
                //Do something
            }
            else if(command == "mark-in-progress")
            {
                //Do something
            }
            else if(command == "mark-done")
            {
                //Do something
            }
            else
            {
                Console.WriteLine("Unknown command.");
                continue;
            }

        }while(string.IsNullOrEmpty(command));
    }
}
