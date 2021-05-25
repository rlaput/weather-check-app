using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCheckApp.DTO
{
    public class ApiResponseErrorDTO
    {
        public ErrorInfoDTO Error { get; set; }
    }

    public class ErrorInfoDTO
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public string Info { get; set; }
    }
}
