using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.SendConfirmation
{
    public class ConfirmationAcknowledgement
    {
        public ConfirmationAcknowledgement(string receipt)
        {
            Receipt = receipt;
        }
        public string Receipt { get; private set; }
    }
}
