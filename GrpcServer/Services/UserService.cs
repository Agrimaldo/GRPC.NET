using Google.Protobuf.Collections;
using Grpc.Core;

namespace GrpcServer.Services
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<SearchReply> Search(SearchRequest request, ServerCallContext context)
        {
            RepeatedField<Register> registerList = new RepeatedField<Register>();

            int dozens = request.Size * request.Page - request.Size;
            SearchReply searchReply = new SearchReply { Total = 100 };

            for (int i = 0; i < request.Size; i++)
            {
                searchReply.Users.Add(new Register 
                { 
                    Id = Guid.NewGuid().ToString(),
                     Name = $"User {dozens+(i+1)}",
                     NickName = $"User {dozens + (i + 1)}",
                     Email = $"User-Mail {dozens + (i + 1)}",
                     CreatedAt = DateTime.Now.ToString()
                });
                Thread.Sleep(2000);
            }

            return Task.FromResult(searchReply);
        }
    }
}
