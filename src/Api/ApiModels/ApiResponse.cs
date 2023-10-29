namespace Sample.Minimal.Api.Api.ApiModels;

public class ApiResponse<TData>
{
    public TData Data { get; private set; }

    public ApiResponse(TData data)
        => Data = data;
}
