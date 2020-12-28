using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.SendConfirmation
{
    public class ConfirmationLetter
    {
        public string Email { get; private set; }
        public string Letter { get; private set; }
        public Uri ConfirmationLink { get; private set; }

        public ConfirmationLetter(string email, string letter, Uri link)
        {
            Email = email;
            Letter = letter;
            ConfirmationLink = link;
        }
    }
}
