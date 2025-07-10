using System.Runtime.Serialization;

namespace ePharmacy.Core.Errors;

public class ImageFileUnexpectedException : BaseException
{
    public ImageFileUnexpectedException() { }
    public ImageFileUnexpectedException(string message) : base(message) { }
    public ImageFileUnexpectedException(string message, Exception inner) : base(message, inner) { }
    protected ImageFileUnexpectedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
