
using BasicMediatR;

namespace MyMediatR.Request.Greet
{
    public class GreetCommandHandler : IRequestHandler<GreetCommand, String>
    {
        public Task<string> HandleAsync(GreetCommand request)
        {
            return Task.FromResult(request.Name);
        }
    }
}
