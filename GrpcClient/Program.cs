using Grpc.Net.Client;

namespace GrpcClient 
{ 
    class Program 
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Wait a few seconds...");
            Thread.Sleep(500);
            using (GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5001"))
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              { 
                var clientGreeter = new Greeter.GreeterClient(channel);
                var reply = await clientGreeter.SayHelloAsync(new HelloRequest { Name = "Aqui no Client Side!" });
                Console.WriteLine($"Server has returned : {reply.Message}");

                var clientCalculator = new Calculator.CalculatorClient(channel);
                var replyCalc = await clientCalculator.AdditionAsync(new ValuesRequest { ValueOne = 10, ValueTwo = 5 });

                Console.WriteLine($"10 + 5 = {replyCalc.Result} -- response with delay ");

            }

            Console.ReadKey();
        }
    }    
}

