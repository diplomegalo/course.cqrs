using System.Security.Cryptography;

namespace Delsoft.Course.CQRS.Model.Commands
{
    public static class CommandExtension
    {
        public static RegisterWine From(this RegisterWine command, Dtos.RegisterWine registerWine)
        {
            command.Appellation = registerWine.Appellation;
            command.Millesime = registerWine.Millesime;
            command.Name = registerWine.Name;

            return command;
        }
    }
}