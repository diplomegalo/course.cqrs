using System.Security.Cryptography;

namespace Delsoft.Course.CQRS.Model.Aggregates
{
    public class Wine
    {
        public string Name { get; }
        public int Millesime { get; }
        public string Appellation { get; }

        public static Wine Create(string name, int millesime, string appellation) => new Wine(name, millesime, appellation);

        private Wine()
        {
        }

        private Wine(string name, int millesime, string appellation)
        {
            this.Name = name;
            this.Millesime = millesime;
            this.Appellation = appellation;
        }
    }
}