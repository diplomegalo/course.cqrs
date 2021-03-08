namespace Delsoft.Course.CQRS.Model.Commands
{
    public class RegisterWine : ICommand
    {
        public string Name { get; set; }
        public int Millesime { get; set; }
        public string Appellation { get; set; }
    }
}