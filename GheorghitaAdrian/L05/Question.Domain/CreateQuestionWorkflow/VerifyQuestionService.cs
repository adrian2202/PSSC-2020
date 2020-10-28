using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.CreateQuestionWorkflow.Question;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class VerifyQuestionService
    {
        public Result<VerifiedQuestion> VerifiedQuestion(UnverifiedQuestion question)
        {
            //implement the verification for title
            return new VerifiedQuestion(question);
        }
    }
}