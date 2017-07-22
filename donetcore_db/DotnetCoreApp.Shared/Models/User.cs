namespace DotnetCoreApp.Shared.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id={Id}\tName={Name}";
        }
    }
}
