using CSharp.Choices;
using LanguageExt.Common;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
	[AsChoice]
	public static partial class Tags
	{
		public interface ITags { }
		public class UnverifiedTags : ITags
		{
			public string Tags { get; private set; }
			private UnverifiedTags(string tags)
			{
				Tags = tags;
			}

			public static AsyncResult<UnverifiedTags> Create(string tags)
			{
				if (IsTagsValid(tags))
				{
					return new UnverifiedTags(tags);
				}
				else
				{
					return new Result<UnverifiedTags>(new InvalidTagsException(tags));
				}
			}
			private static bool IsTagsValid(string tags)
			{
				String[] numberTags = new String[];
				numberTags = tags.Split(" ");
				if (numberTags.Length >= 1 && numberTags.Length<=3)
				{
					return true;
				}
				return false;
			}
		}
		public class VerifiedTags : ITags
		{
			public string Tags { get; private set; }
			internal VerifiedTags(string tags)
			{
				Tags = tags;
			}
		}
	}
}