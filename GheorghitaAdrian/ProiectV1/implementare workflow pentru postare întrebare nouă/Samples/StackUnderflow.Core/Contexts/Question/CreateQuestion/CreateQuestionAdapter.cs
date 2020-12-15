using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Access.Primitives.IO.Mocking;
//using StackUnderflow.DatabaseModel.Models;
using StackUnderflow.Domain.Schema.Models;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion.CreateQuestionResult;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion
{
    public partial class CreateQuestionAdapter : Adapter<CreateQuestionCmd, ICreateQuestionResult, QuestionWriteContext, QuestionDependencies>
    {
        private readonly IExecutionContext _ex;
        public CreateQuestionAdapter(IExecutionContext ex)
        {
            _ex = ex;
        }
        public override async Task<ICreateQuestionResult> Work(CreateQuestionCmd command, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var workflow = from valid in command.TryValidate()
                           let t = AddQuestionMissing(state, CreateQuestionFromCommand(command))
                           select t;

            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new InvalidRequest(ex.ToString()));
            return result;
        }

        public ICreateQuestionResult AddQuestionMissing(QuestionWriteContext state, QuestionSummary questionSummary)
        {
            if (state.QuestionSummaries.Any(p => p.Title.Equals(questionSummary.Title))) ////////////////
                return new QuestionNotCreated();

            if (state.QuestionSummaries.All(p => p.QuestionId != questionSummary.QuestionId))
                state.QuestionSummaries.Add(questionSummary);
            return new QuestionCreated(questionSummary);
        }

        private QuestionSummary CreateQuestionFromCommand(CreateQuestionCmd cmd)
        {
            var questionSummary = new QuestionSummary()
            {
                Title = cmd.Title,
                Body = cmd.Body,
                Tags = cmd.Tags
            };
            return questionSummary;
        }
        public override Task PostConditions(CreateQuestionCmd op, CreateQuestionResult.ICreateQuestionResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }
    }
}
