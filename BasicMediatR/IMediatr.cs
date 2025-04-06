namespace BasicMediatR
{
    public interface IMediatr
    {
        Task<TResponse> SendAsync<TResponse >(IRequest<TResponse> request);
    }
}
