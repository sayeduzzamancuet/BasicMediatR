
using BasicMediatR;

namespace MyMediatR.Request.Print
{
    public class PrintToConsoleRequest:IRequest<bool>
    {
        public string Text { get; set; }
    }
}
