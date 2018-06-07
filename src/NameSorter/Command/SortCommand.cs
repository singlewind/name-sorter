namespace NameSorter.Command
{
    using Microsoft.Extensions.CommandLineUtils;
    using System;
    using System.Diagnostics;
    using System.IO;

    public class SortCommand 
    {
        public static void Configure(CommandLineApplication app)
        {
            var fileArgument = app.Argument("[file]", "names in text file for sort.");
            
            app.OnExecute(() => 
            {
                (new SortCommand(app)).Process(fileArgument);
                return 0;
            });
        }

        private readonly CommandLineApplication _app;

        public SortCommand(CommandLineApplication app)
        {
            _app = app;
        }        

        public void Process(CommandArgument fileArgument)
        {
            try
            {
                var file = fileArgument.Value;
                if (string.IsNullOrWhiteSpace(file))
                {
                    _app.ShowHelp();
                }
                if (!File.Exists(file)) throw new Exception($"{file} not found.");
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Console.WriteLine("Start processing...");
                Console.WriteLine($"Finished. It took {stopWatch.Elapsed.TotalSeconds} seconds.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);              
            }          
        }
    }
}
