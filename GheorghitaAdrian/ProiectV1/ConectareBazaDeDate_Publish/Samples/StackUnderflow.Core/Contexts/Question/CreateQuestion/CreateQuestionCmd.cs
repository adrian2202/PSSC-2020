using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion
{
    public struct CreateQuestionCmd
    {
        public CreateQuestionCmd(int questionId, string title, string body, ICollection<string> tags)
        {
            QuestionId = questionId;
            Title = title;
            Body = body;
            Tags = tags;
        }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
