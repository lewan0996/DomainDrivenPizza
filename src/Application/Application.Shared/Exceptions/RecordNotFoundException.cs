using System;

namespace Application.Shared.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public int RecordId { get; }

        public RecordNotFoundException(int recordId) : base($"Record of the id {recordId} was not found")
        {
            RecordId = recordId;
        }
    }
}
