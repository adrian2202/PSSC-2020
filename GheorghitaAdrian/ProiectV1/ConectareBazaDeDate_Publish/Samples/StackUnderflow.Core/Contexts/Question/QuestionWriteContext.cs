using StackUnderflow.Domain.Schema.Models;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public class QuestionWriteContext
    {
        public ICollection<Post> Posts { get; }

        public QuestionWriteContext(ICollection<Post> posts)
        {
            Posts = posts ?? new List<Post>(0);
        }
    }
}
