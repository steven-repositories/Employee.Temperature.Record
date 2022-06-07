﻿using System;

namespace Employee.Temperature.Record.Api.Utilities {
    /// <summary>
    /// General error occured.
    /// </summary>
    public class ApiException : Exception {
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public ApiException(string message = null, Exception innerException = null) : base(message, innerException) { }
    }

    /// <summary>
    /// Builder error occured against the builder.
    /// </summary>
    public class BuilderException : Exception {
        /// <param name="message">Exception message</param>
        public BuilderException(string message = null) : base(message) { }
    }

    /// <summary>
    /// Controller processing request error occured against the builder.
    /// </summary>
    public class ControllerException : Exception {
        /// <param name="message">Exception message</param>
        public ControllerException(string message = null) : base(message) { }
    }
}
