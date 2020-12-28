using StackUnderflow.Domain.Schema.Models;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public class QuestionReadContext
    {
        public IEnumerable<Post> Posts { get; }
        public QuestionReadContext(IEnumerable<Post> posts)
        {
            Posts = posts;
        }
    }
}
