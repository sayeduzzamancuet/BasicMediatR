
using BasicMediatR;

namespace MyMediatR.Request.Print
{
    public class PrintToConsoleHandler : IRequestHandler<PrintToConsoleRequest, bool>
    {
        public Task<bool> HandleAsync(PrintToConsoleRequest request)
        {
            Console.Out.WriteLine(request.Text);
            return Task.FromResult(true);
        }
    }
}
