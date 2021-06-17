using SpicyX.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Email
{
	public interface IEmailSender
	{
		void Send(SendEmailDto dto);
	}
}
