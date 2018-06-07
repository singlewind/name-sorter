namespace NameSorter
{    
    using Microsoft.Extensions.CommandLineUtils;
    using Command;

    class Program
    {
        static void Main(string[] args)
        {
            // setup description of this application
            var app = new CommandLineApplication();
            app.Name = "name-sorter";            
            app.Description = "This command tool help to sort names by last name then given name.";
            app.HelpOption("-? | -h | --help");

            // configure sort command
            SortCommand.Configure(app);
            app.Execute(args);
        }
    }
}
