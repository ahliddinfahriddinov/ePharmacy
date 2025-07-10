﻿using System.Runtime.Serialization;

namespace ePharmacy.Core.Errors;

public class UnauthorizedException : BaseException
{
    public UnauthorizedException() { }
    public UnauthorizedException(string message) : base(message) { }
    public UnauthorizedException(string message, Exception inner) : base(message, inner) { }
    protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

