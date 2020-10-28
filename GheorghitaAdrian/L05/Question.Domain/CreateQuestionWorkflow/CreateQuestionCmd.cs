using System;

namespace QuestionBoundedContext.QuestionContext
{
    public struct CreateQuestionCmd
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Description { get; private set; }
        [Required]
        public string Tags { get; private set; }
        [Required]
        public int Votes { get; private set; }

        public bool CanVote = false;

        public CreateQuestionCmd(string Title, string Description, string Tags, int Votes)
        {
            this.Title = Title;
            this.Description = Description;
            this.Tags = Tags;
            this.Votes = Votes;
            
        }
    }
}