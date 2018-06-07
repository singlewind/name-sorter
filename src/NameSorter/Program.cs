namespace NameSorter
{    
    using Microsoft.Extensions.CommandLineUtils;
    using Command;

    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.Name = "name-sorter";
            app.Description = "This command tool help to sort names by last name then given name.";
            app.HelpOption("-? | -h | --help");

            SortCommand.Configure(app);
            app.Execute(args);
        }
    }
}
