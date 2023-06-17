﻿using Reminder.BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}
