namespace NameSorter
{
    using Microsoft.Extensions;
    using Microsoft.Extensions.CommandLineUtils;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.Name = "name-sorter";
            app.Description = "Help sort names by last name then given name.";
            app.HelpOption("-?|-h|--help");

            var fileOption = app.Option("-f|--file <file>", "names in text file for sort", CommandOptionType.SingleValue);

            app.OnExecute(() => {
                var file = fileOption.Value();
                Console.Write($"Reading file... {file}");
                return 0;
            });

            app.Execute(args);
        }
    }
}
