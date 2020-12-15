using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.SendConfirmation
{
    public static partial class ConfirmationQuestionResult
    {
        public interface IConfirmationQuestionResult { }
        public class QuestionConfirmed : IConfirmationQuestionResult
        {
            public User QuestionUser { get; }
            public string ConfirmationAcknowledgement { get; set; }

            public QuestionConfirmed(User questionUser, string confirmationAcknowledgement)
            {
                QuestionUser = questionUser;
                ConfirmationAcknowledgement = confirmationAcknowledgement;
            }
        }
        public class QuestionNotConfirmed : IConfirmationQuestionResult
        {

        }
        public class InvalidRequest : IConfirmationQuestionResult
        {
            public InvalidRequest(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }
    }
}
