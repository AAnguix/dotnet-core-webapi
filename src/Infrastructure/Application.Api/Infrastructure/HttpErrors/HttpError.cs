﻿namespace Application.Api.Infrastructure
{
    using Microsoft.AspNetCore.Hosting;
    using System.Net;

    public class HttpError
    {
        public int Status { get; set; }

        public string Code { get; set; }

        public string[] UserMessage { get; set; }

        public string DeveloperMessage { get; set; }

        public string[] ValidationErrors { get; set; }

        public static HttpError CreateHttpValidationError(
            HttpStatusCode status,
            string[] userMessage,
            string[] validationErrors)
        {
            HttpError httpError = CreateDefaultHttpError(status, userMessage);

            httpError.ValidationErrors = validationErrors;

            return httpError;

        }

        public static HttpError Create(
            IHostingEnvironment environment,
            HttpStatusCode status,
            string code,
            string[] userMessage,
            string developerMessage)
        {
            HttpError httpError = CreateDefaultHttpError(status, userMessage);

            httpError.Code = code;

            if (environment.IsDevelopment())
            {
                httpError.DeveloperMessage = developerMessage;
            }

            return httpError;
        }

        public static HttpError CreateDefaultHttpError(
            HttpStatusCode status,
            string[] userMessage)
        {
            return new HttpError { Status = (int)status, UserMessage = userMessage };
        }
    }
}