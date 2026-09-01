using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.Shared
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }

        public static ApiResponse<T> SuccessResponse(T? data)
        {
            return new ApiResponse<T>
            {
                Data = data,
                IsSuccess = true
            };
        }

        public static ApiResponse<T> ErrorResponse(string? errorMessage)
        {
            return new ApiResponse<T>
            {
                ErrorMessage = errorMessage,
                IsSuccess = false
            };
        }
    }
}
