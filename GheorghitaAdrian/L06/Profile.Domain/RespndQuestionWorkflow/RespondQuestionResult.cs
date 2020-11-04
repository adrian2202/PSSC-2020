using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Profile.Domain.RespndQuestionWorkflow
{
    public static partial class RespondQuestionResult
    {
        public interface IReplay
        {
        }

        public class ReplayNotPublish : IReplay
        {
            public string Reason { get; set; }

            public ReplayNotPublish(string reason)
            {
                Reason = reason;
            }
        }

        public class InvalidReplay : IReplay
        {
            public IEnumerable<object> RespondInvalid { get; private set; }

            public InvalidReplay(IEnumerable<string> errors)
            {
                RespondInvalid = errors.AsEnumerable();
            }
        }

        public class ReplayPublished : IReplay
        {
            public string Body { get; }
            public ReplayPublished(string body)
            {
                Body = body;
            }
        }
    }
}
