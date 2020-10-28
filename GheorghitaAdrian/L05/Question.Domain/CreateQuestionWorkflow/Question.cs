using CSharp.Choices;
using LanguageExt.Common;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
	[AsChoice]
	public static partial class Question
	{
		public interface IQuestion { }
		public class UnverifiedQuestion : IQuestion
		{
			public string Question { get; private set; }
			private UnverifiedQuestion(string question)
			{
				Question = question;
			}

			public static AsyncResult<UnverifiedQuestion> Create(string question)
			{
				if (IsQuestionValid(question))
				{
					return new UnverifiedQuestion(question);
				}
				else
				{
					return new Result<UnverifiedQuestion>(new InvalidQuestionException(question));
				}
			}
			private static bool IsQuestionValid(Question question)
			{
				if (question.Length <= 1000)
				{
					enableVoting(question);
					return true;
				}
				return false;
			}
		}
		public class VerifiedQuestion : IQuestion
		{
			public string Question { get; private set; }
			internal VerifiedQuestion(string question)
			{
				Question = question;
			}
		}
	}
}