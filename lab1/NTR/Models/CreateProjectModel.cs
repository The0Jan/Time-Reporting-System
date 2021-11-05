

using System;

namespace NTR.Models
{
    public class CreateProjectModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}