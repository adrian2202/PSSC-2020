using System.Runtime.Remoting.Messaging;

namespace Question.Domain.CreateQuestionWorkflow
{
    [AsChoice]
    public static partial class Votes
    {
        public interface IVotes { }
        public class UnverifiedNumberVotes : IVotes
        {
            public int Votes { get; private set; }
            private UnverifiedNumberVotes(int votes)
            {
                Votes = votes;
            }

            public static AsyncResult<UnverifiedNumberVotes> Create(int votes)
            {
                if (IsVotesValid(vote))
                {
                    return new UnverifiedNumberVotes(votes);
                }
                else
                {
                    return new Result<UnverifiedNumberVotes>(new InvalidVotesException(votes));
                }
            }
            private static bool IsVotesValid(int votes)
            {
                if(Votes == votes)
                {
                    return true;
                }
                return false;
            }
        }
        public class VerifiedVotes : IVotes
        {
            public int Votes { get; private set; }
            internal VerifiedVotes(int votes)
            {
                Votes = votes;
            }
        }
    }
}