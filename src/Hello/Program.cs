using Hello;

var greetingService = new GreetingService();
var result = greetingService.Process(args);

Console.WriteLine(result.Message);
return result.ExitCode;
