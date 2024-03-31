namespace FamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var grandMother = new FamilyMember() { Mother = null, Father = null, Name = "Бабушка", Sex = Gender.Female };
            var grandFather = new FamilyMember() { Mother = null, Father = null, Name = "Дедушка", Sex = Gender.Male };
            var father = new FamilyMember() { Mother = null, Father = null, Name = "Папа", Sex = Gender.Male };
            var mother = new FamilyMember() { Mother = grandMother, Father = grandFather, Name = "Мама", Sex = Gender.Female };
            grandMother.AddChild(mother);
            grandFather.AddChild(mother);
            var son = new FamilyMember() { Mother = mother, Father = father, Name = "Сын", Sex = Gender.Male };
            var daughter = new FamilyMember() { Mother = mother, Father = father, Name = "Дочка", Sex = Gender.Female };
            var daughter2 = new FamilyMember() { Mother = null, Father = father, Name = "Дочка2", Sex = Gender.Female };
            mother.AddChild(son);
            father.AddChild(son);
            mother.AddChild(daughter);
            father.AddChild(daughter);
            father.AddChild(daughter2);

            father.CloseRelatives();
            Console.WriteLine();
            mother.CloseRelatives();
            Console.WriteLine();
            son.CloseRelatives();
            Console.WriteLine();
            daughter.CloseRelatives();
            Console.WriteLine();
            daughter2.CloseRelatives();
            Console.WriteLine();
        }
    }
}
