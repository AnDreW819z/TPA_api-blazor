namespace tparf.Api.EmailSender
{
	public interface IEmailService
	{
		public Task SendEmail(Message message);
	}
}
