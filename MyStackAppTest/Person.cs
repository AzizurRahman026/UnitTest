
namespace MyStackAppTest
{
    public class Person
    {
        public string Name { get; set; }
        public bool IsGraduated { get; set; }

        public Person(string name, bool isGraduated)
        {
            this.Name = name;
            this.IsGraduated = isGraduated;
        }
    }
}
