using CSharp.Choices;
using LanguageExt.Common;
using System.Collections.Generic;
using System.Text;

namespace Profile.Domain.RespndQuestionWorkflow
{
    [AsChoice]
    public partial class BodyReplay
    {
        public interface IReplay{}

        public partial class Replay : IReplay
        {
            public bool IsVerified { get; private set; }

            private Replay(string body)
            {
                Body = body;
            }

            public string Body { get; }


            public static Result<Replay> CreateBody(string body)
            {
                if (IsBodyQuestionValid(body))
                {
                    return new Replay(body);
                }
                else
                {
                    return new Result<Replay>(new InvalidBodyException(body));
                }
            }



            public static bool IsBodyQuestionValid(string body)
            {
                if (body.Length > 10  && body.Length <= 500)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        public class ValidateReplay : IReplay
        {
            public string Body { get; private set; }

            internal ValidateReplay(string body)
            {
                Body = body;
            }
        }
        }

    }
}
