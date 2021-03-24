using System;

namespace Delsoft.Course.CQRS.Domain.Commands.Decorators
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class LoggingAttribute : Attribute
    {
        public LoggingAttribute()
        {

        }
    }
}