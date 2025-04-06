
using BasicMediatR;

namespace MyMediatR.Request.Greet
{
    public class GreetCommand:IRequest<String>
    {
        public String Name { get; set; }
    }
}
