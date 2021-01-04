using Access.Primitives.IO;
using EarlyPay.Primitives.ValidationAttributes;
using LanguageExt;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.SendConfirmation
{
    public struct ConfirmationQuestionCmd
    {
        [OptionValidator(typeof(RequiredAttribute))]
        public Option<User> QuestionUser { get; }

        public ConfirmationQuestionCmd(Option<User> questionUser)
        {
            QuestionUser = questionUser;
        }
    }

    public enum ConfirmationQuestionCmdInput
    {
        Valid,
        UserIsNone
    }

    public class ConfirmationQuestionInputGen : InputGenerator<ConfirmationQuestionCmd, ConfirmationQuestionCmdInput>
    {
        public ConfirmationQuestionInputGen()
        {
            mappings.Add(ConfirmationQuestionCmdInput.Valid, () =>
            new ConfirmationQuestionCmd(

                Option<User>.Some(new User()
                {
                    DisplayName = Guid.NewGuid().ToString(),
                    Email = $"{Guid.NewGuid()}@mailinator.com"
                } ) )
            );

            mappings.Add(ConfirmationQuestionCmdInput.UserIsNone, () =>
            new ConfirmationQuestionCmd(
                Option<User>.None
                )
            );
        }
    }
}
