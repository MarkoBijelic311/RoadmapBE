namespace TaskTracer;

class Program
{
    static void Main(string[] args)
    {

        ToDoService todoService = new ToDoService();

        while(true){

            Console.WriteLine("> ");
            var command = Console.ReadLine();
            string[] arg = string.IsNullOrWhiteSpace(command) 
            ? Array.Empty<string>() 
            : command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

            if (string.IsNullOrWhiteSpace(command))
                continue;

            if (arg[0] == "exit")
                break;

           if(arg[0] == "add")
            {
                todoService.Add(arg[1]);
            }
            else if(arg[0] == "update")
            {
                string[] argument = arg[1].Split('/', 2, StringSplitOptions.RemoveEmptyEntries);
                todoService.Update(argument[0], argument[1]);
            }
            else if(arg[0] == "delete")
            {
                todoService.Remove(arg[1]);
            }
            else if(arg[0] == "list")
            {
                Console.WriteLine(todoService.GetAll());
            }
            else if(arg[0] == "mark-in-progress")
            {
                todoService.MarkInProgress(arg[1]);
            }
            else if(arg[0] == "mark-pending")
            {
                todoService.MarkPending(arg[1]);
            }
            else if(arg[0] == "mark-done")
            {
                todoService.MarkDone(arg[1]);
            }
            else
            {
                Console.WriteLine("Unknown command.");
                continue;
            }

        }
    }
}
