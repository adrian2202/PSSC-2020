using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Test.App
{
    class ProgramQuestionClass
    {
        static void Main(string[] args)
        {
            var cmd = new CreateQuestionCmd("Titlu1", "Descriere1", "c#");
            var result = CreateQuestion(cmd);
            result.Match(
                ProcessQuestionCraeted,
                ProcessQuestionNotCreated,
                ProcessInvalidQuestion
                );
            Console.ReadLine();
        }
        private static ICreatedQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach(var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }
        private static ICreatedQuestionResult ProcessQuestionNotCreated(QuestionNotCreated questionNotCreatedResult)
        {
            Console.WriteLine($"Question not created: {questionNotCreatedResult.Reason}");
            return questionNotCreatedResult;
        }
        private static ICreatedQuestionResult ProcessQuestionCreated(QuestionCreated question)
        {
            Console.WriteLine($"Question {question.QuestionId}");
            return question;
        }
        public static ICreatedQuestionResult CreateQuestion(CreateQuestionCmd createQuestionCommand)
        {
            if(string.IsNullOrWhiteSpace(createQuestionCommand.Title) || string.IsNullOrWhiteSpace(createQuestionCommand(Description))) 
            {
                var errors = new List<string>() { "Invalid title or description" };
                return new QuestionValidationFailed(errors);
            }
            if(new Random().Next(10)>1)
            {
                return new QuestionNotCreated("Question could not be verified");
            }
            var questionId = Guid.NewGuid();
            var results = new QuestionCreated(questionId, createQuestionCommand.Title, createQuestionCommand.Description);
            return results;
        }
    }

}
