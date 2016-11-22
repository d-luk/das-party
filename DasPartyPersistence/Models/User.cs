namespace DasPartyPersistence.Models
{
    public class User
    {
        public string ID { get; }
        public string Name { get; }

        public User(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}