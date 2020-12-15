using StackUnderflow.Domain.Schema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public class QuestionWriteContext
    {
        public ICollection<QuestionSummary> QuestionSummaries { get; }

        public QuestionWriteContext(ICollection<QuestionSummary> questionSummaries)
        {
            QuestionSummaries = questionSummaries ?? new List<QuestionSummary>(0);
        }
    }
}
