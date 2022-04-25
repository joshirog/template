using System;
using Monkeylab.Templates.Application.Commons.Interfaces;

namespace Monkeylab.Templates.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}