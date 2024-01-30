using Grpc.Core;
using GrpcServer;

namespace GrpcServer.Services
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        private readonly ILogger<CalculatorService> _logger;
        public CalculatorService(ILogger<CalculatorService> logger)
        {
            _logger = logger;
        }
        public override Task<ResultReply> Addition(ValuesRequest request, ServerCallContext context)
        {
            Thread.Sleep(5000);
            return Task.FromResult(new ResultReply
            {
                Result = request.ValueOne + request.ValueTwo
            });
        }
        public override Task<ResultReply> Subtraction(ValuesRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ResultReply
            {
                Result = request.ValueOne - request.ValueTwo
            });
        }
        public override Task<ResultReply> Division(ValuesRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ResultReply
            {
                Result = request.ValueOne / request.ValueTwo
            });
        }
        public override Task<ResultReply> Multiplication(ValuesRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ResultReply
            {
                Result = request.ValueOne * request.ValueTwo
            });
        }

    }
}
