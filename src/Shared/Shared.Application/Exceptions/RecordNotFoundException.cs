using System;

namespace Shared.Application.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int RecordId { get; }

        public RecordNotFoundException(int recordId, string typeName) : base($"Record of the type {typeName} of the id {recordId} was not found")
        {
            RecordId = recordId;
        }
    }
}
