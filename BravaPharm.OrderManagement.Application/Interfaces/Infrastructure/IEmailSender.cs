using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Application.Models;

namespace BravaPharm.OrderManagement.Application.Interfaces.Infrastructure
{
    public interface IEmailSender
    {
        Task SendEmail(Email email);
    }
}
