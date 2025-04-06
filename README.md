# Basic MediatR Library: An Alternative to the Popular .NET [MediatR](https://github.com/jbogard/MediatR "MediatR GitHub Repository") Library

You can use the Basic MediatR library as follows:

```csharp
builder.Services.AddBasicMediatR(typeof(Program).Assembly);
var app = builder.Build();
