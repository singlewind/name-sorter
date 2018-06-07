namespace NameSorter.Command
{
    using Microsoft.Extensions.CommandLineUtils;
    using Microsoft.Extensions.DependencyInjection;
    using NameSorter.Services;
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Sort command to sort names in a txt file
    /// </summary>
    public class SortCommand 
    {
        public static void Configure(CommandLineApplication app)
        {
            // setup two arguments
            var fileArgument = app.Argument("[file]", "names in text file for sort.");
            var outputArgument = app.Argument("[output]", "save to a text file after sorted.");

            app.OnExecute(() => 
            {
                (new SortCommand(app)).Process(fileArgument, outputArgument);
                return 0;
            });
        }

        private readonly CommandLineApplication _app;

        /// <summary>
        /// Constructor for SortCommand
        /// </summary>
        /// <param name="app"></param>
        public SortCommand(CommandLineApplication app)
        {
            _app = app;
        }                

        /// <summary>
        /// Sort names in the text file
        /// </summary>
        /// <param name="fileArgument">input file</param>
        /// <param name="outputArgument">output file</param>
        public void Process(CommandArgument fileArgument, CommandArgument outputArgument)
        {
            try
            {
                // validate input file 
                var file = fileArgument.Value;
                if (string.IsNullOrWhiteSpace(file))
                {
                    _app.ShowHelp();
                }
                if (!File.Exists(file)) throw new Exception($"{file} not found.");

                // optional output file
                var output = outputArgument.Value;
                if (string.IsNullOrWhiteSpace(output))
                {
                    var input = new FileInfo(file);
                    output = Path.Join(input.Directory.FullName, "sorted-names.txt");
                }


                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Console.WriteLine("Start processing...");

                // Setup container. It is not necessary a case use IoC here. It is only for demonstrating understandings.
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<IInputService>(new FileInputService(file));
                serviceCollection.AddSingleton<IOutputService>(new FileOutputService(output));
                serviceCollection.AddSingleton(new NameStringComparer());
                var serviceProvider = serviceCollection.BuildServiceProvider();

                var inputService = serviceProvider.GetRequiredService<IInputService>();
                var outputService = serviceProvider.GetRequiredService<IOutputService>();
                var comparer = serviceProvider.GetRequiredService<NameStringComparer>();

                var data = inputService.Read();
                Array.Sort(data, comparer);
                outputService.Write(data);

                Console.WriteLine($"Finished. It took {stopWatch.Elapsed.TotalSeconds} seconds for {data.Length} names.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);              
            }          
        }
    }
}
