using GrainInterfaces;
using Orleans;
using System.Threading.Tasks;

namespace FakeSO.API.Rest
{
    public class EmailSenderGrain : Grain, IEmailSender
    {
        public Task<string> SendEmailAsync(string message)
        {
            //todo send e-mail

            return Task.FromResult(message);
        }
    }
}