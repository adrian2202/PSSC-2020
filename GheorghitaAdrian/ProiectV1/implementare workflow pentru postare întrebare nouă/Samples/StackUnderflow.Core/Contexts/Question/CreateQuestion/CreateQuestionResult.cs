using Access.Primitives.Extensions.Cloning;
using CSharp.Choices;
using StackUnderflow.Domain.Schema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult : IDynClonable { }

        public class QuestionCreated : ICreateQuestionResult
        {
            public QuestionSummary QuestionSummary { get; }

            public QuestionCreated(QuestionSummary questionSummary)
            {
                QuestionSummary = questionSummary;
            }
            public object Clone() => this.ShallowClone();
        }

        public class QuestionNotCreated : ICreateQuestionResult
        {
            public string Reason { get; private set; }

            //TODO
            public object Clone() => this.ShallowClone();
        }

        public class InvalidRequest : ICreateQuestionResult
        {
            public string Message { get; }
            public InvalidRequest(string message)
            {
                Message = message;
            }
            //TODO
            public object Clone() => this.ShallowClone();
        }
    }
}
