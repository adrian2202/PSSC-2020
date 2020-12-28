using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion;
using StackUnderflow.Domain.Core.Contexts.Question.SendConfirmation;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;
using static StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion.CreateQuestionResult;
using static StackUnderflow.Domain.Core.Contexts.Question.SendConfirmation.ConfirmationQuestionResult;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public static class QuestionDomain
    {
        public static Port<ICreateQuestionResult> CreateQuestion(CreateQuestionCmd command) => NewPort<CreateQuestionCmd, ICreateQuestionResult>(command);

        public static Port<IConfirmationQuestionResult> ConfirmQuestion(ConfirmationQuestionCmd command) => NewPort<ConfirmationQuestionCmd, IConfirmationQuestionResult>(command);
    }
}
