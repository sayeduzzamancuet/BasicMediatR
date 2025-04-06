
using Microsoft.Extensions.DependencyInjection;

namespace BasicMediatR
{
    public class Mediatr : IMediatr
    {
        private readonly IServiceProvider _serviceProvider;

        // Constructor accepting DI container
        public Mediatr(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var requestType = request.GetType();
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));
            var handler = _serviceProvider.GetRequiredService(handlerType);

            var method = handlerType.GetMethod("HandleAsync");
            if (method == null)
                throw new InvalidOperationException($"HandleAsync not found on handler type {handlerType.Name}");

            var task = (Task)method.Invoke(handler, new object[] { request });

            await task.ConfigureAwait(false);
            var resultProperty = task.GetType().GetProperty("Result");
            return (TResponse)resultProperty.GetValue(task);
        }


    }
}
