# Basic MediatR library, alternative to popular .net MediatR library

Use it like below:

builder.Services.AddBasicMediatR(typeof(Program).Assembly);
var app = builder.Build();
