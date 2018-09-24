namespace Application.Api.Infrastructure
{
    using System;

    public interface IHttpErrorFactory
    {
        HttpError CreateFrom(Exception exception);
    }
}