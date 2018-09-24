namespace Application.Api.Infrastructure
{
    using System;

    class DefaultHttpErrorFactory : IHttpErrorFactory
    {
        public HttpError CreateFrom(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
