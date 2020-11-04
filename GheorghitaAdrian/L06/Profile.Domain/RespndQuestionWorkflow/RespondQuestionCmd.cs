using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.domain4.RespondQuestionWorkflow
{
    public struct RespondQuestionCmd
    {
        public RespondQuestionCmd(int questionId, string name, string body)
        {
            QuestionId = questionId;
            Name = name;
            Body = body;
        }

        [Required]
        public string Body { get; private set; }
        [Required]
        public int QuestionId { get; private set; }
        [Required]
        public string Name { get; private set; }
    }
}
