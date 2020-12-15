using System;

namespace BeTheHero.Domain.Model
{
    public class ONG
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string City { get; set; }
        public string UF { get; set; }

        public ONG()
        {
            Id = Guid.NewGuid();
        }
    }
}
