using StackUnderflow.Domain.Schema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public class QuestionReadContext
    {
        public QuestionReadContext(IEnumerable<QuestionSummary> questions)
        {
            Questions = questions;
        }
        public IEnumerable<QuestionSummary> Questions { get; }
    }
}
