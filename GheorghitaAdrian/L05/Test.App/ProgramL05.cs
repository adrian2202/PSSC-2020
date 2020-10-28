using LanguageExt;
using LanguageExt.Common;
using Profile.Domain.CreateProfileWorkflow;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using static Profile.Domain.CreateProfileWorkflow.CreateProfileResult;
using static Profile.Domain.CreateProfileWorkflow.EmailAddress;
using System.Security;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tags = new List<string>()
            {
                "Java",
                "Coding",
                "Version"
            };
            
            var result = UnverifiedQuestion.Create("Can I do this in Java?");


            result.Match(
                    Succ: question =>
                    {
                        EnableVoteQuestion(question);

                        Console.WriteLine("Question is available for voting.");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Question was not posted because: {ex.Message}");
                        return Unit.Default;
                    }
                );


            Console.ReadLine();
        }

        private static void EnableVoteQuestion(UnverifiedQuestionDescription question)
        {
            var verifiedQuestionResult = new verifyQuestionService().Create(question);
            verifiedQuestionResult.Match(
                    EnableVoteQuestion =>
                    {
                        new VerifyVoteService().Vote(EnableVoteQuestion).Wait();
                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("This question can't be voted");
                        return Unit.Default;
                    }
                );
        }
    }
}
