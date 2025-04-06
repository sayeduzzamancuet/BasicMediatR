# Basic MediatR Library: An Alternative to the Popular .NET [MediatR](https://github.com/jbogard/MediatR "MediatR GitHub Repository") Library

You can use the Basic MediatR library as follows:

```csharp
//Request
public class PrintToConsoleRequest:IRequest<bool>
{
    public string Text { get; set; }
}

//Command handler
public class PrintToConsoleHandler : IRequestHandler<PrintToConsoleRequest, bool>
 {
     public Task<bool> HandleAsync(PrintToConsoleRequest request)
     {
         return Task.FromResult(true);
     }
 }

//Controller
var request = new PrintToConsoleRequest
{
    Text = "Hello world !"
};
var result = await mediatr.SendAsync(request);

//Program.cs
builder.Services.AddBasicMediatR(typeof(Program).Assembly);
var app = builder.Build();
