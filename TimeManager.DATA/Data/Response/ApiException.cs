﻿namespace TimeManager.DATA.Data.Response
{
    public class ApiException : IApiException
    {
        public string Description { get; set; }

        public ApiException(Exception ex)
        {
            Description = ex.Message;
        }

    }
}