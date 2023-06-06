using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public enum ErrorCodes
    {
        NOT_FOUND = 1,
        COULD_NOT_STORE_DATA = 2,
        INVALID_PERSON_ID = 3,
        MISSING_REQUIRED_INFORMATION = 4
    }
    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public ErrorCodes ErrorCode { get; set; }
    }
}
