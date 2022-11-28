// ReSharper disable UnusedAutoPropertyAccessor.Global

#pragma warning disable CS8618

namespace FinalProject.Models;

using System.Net;

public class Response
{
    public HttpStatusCode StatusCode { get; init; }

    public string StatusDescription { get; init; }
}

public class Response<TResult> where TResult : class
{
    public TResult Result { get; init; }

    public HttpStatusCode StatusCode { get; init; }

    public string StatusDescription { get; init; }
}
