﻿namespace Sample.Minimal.Api.Api.ApiModels;

public class ApiResponseList<TItemData>
    : ApiResponse<IReadOnlyList<TItemData>>
{
    public ApiResponseList(IReadOnlyList<TItemData> data)
        : base(data)
    {
    }
}
