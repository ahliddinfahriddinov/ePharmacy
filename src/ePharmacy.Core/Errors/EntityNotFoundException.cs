﻿using System.Runtime.Serialization;

namespace ePharmacy.Core.Errors;

[Serializable]
public class EntityNotFoundException : BaseException
{
    public EntityNotFoundException() { }
    public EntityNotFoundException(string message) : base(message) { }
    public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }
    protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
