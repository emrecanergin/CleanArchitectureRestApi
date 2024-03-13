﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Responses.Api
{
    public class ApiResponse<T> where T : class
    {
        //FOR XML RESPONSE
        public ApiResponse()
        {

        }
        public ApiResponse(T extra)
        {
            Success = true;
            Data = extra;
            TimeStamps = DateTime.UtcNow;
        }
        public ApiResponse(bool success)
        {
            Success = success;
            TimeStamps = DateTime.UtcNow;
        }
        public ApiResponse(bool success,string message)
        {
            Success = success;
            Message = message;
            TimeStamps = DateTime.UtcNow;
        }

        public ApiResponse(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
            TimeStamps = DateTime.UtcNow;
        }

        public int StatusCode { get; set; }

        public T Data { get; set; }

        //[JsonProperty(Order = -2)]
        public bool Success { get; set; }

        //[JsonProperty(Order = -4)]
        public DateTime TimeStamps { get; set; }

        //[JsonProperty(Order = -3)]
        public string TotalProcessTime { get; set; }

        public string Message { get; set; }

        public string ErrorMessage { get; set; }

    }
}
