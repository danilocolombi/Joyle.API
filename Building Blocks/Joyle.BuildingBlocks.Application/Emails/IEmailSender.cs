using System.Threading.Tasks;

namespace Joyle.BuildingBlocks.Application.Emails
{
    public interface IEmailSender
    {
        Task Send(EmailMessage message);
    }
}
