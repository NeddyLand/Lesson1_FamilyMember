using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyMember
{
    enum Gender { Male, Female };
    internal class FamilyMember
    {
        public FamilyMember Mother { get { return mother; } set { mother = value; } }
        public FamilyMember Father { get { return father; } set { father = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Gender Sex { get { return sex; } set { sex = value; } }
        public List<FamilyMember> Children { get; }

        FamilyMember mother;
        FamilyMember father;
        string name;
        Gender sex;
        List<FamilyMember> children;

        public FamilyMember()
        {
            children = new List<FamilyMember>();
        }
        public FamilyMember(FamilyMember mother, FamilyMember father, string name, Gender gender)
        {
            children = new List<FamilyMember>();
            this.mother = mother;
            this.father = father;
            this.name = name;
            this.sex = gender;
        }
        public void AddChild(FamilyMember child)
        {
            if (child != null)
            {
                children.Add(child);
            }
        }
        public void FemaleLine()
        {
            if (sex == Gender.Female)
            {
                Console.WriteLine(name);
            }
            FemaleLinePrivate();
        }
        private void FemaleLinePrivate()
        {
            if (mother != null)
            {
                Console.WriteLine(mother.name);
                mother.FemaleLinePrivate();
            }
        }
        public void CloseRelatives()
        {
            Console.WriteLine($"Я - {name}");
            Console.WriteLine("Близкие родственники.");
            Console.WriteLine("Родители:");
            if (mother != null)
            {
                Console.WriteLine($"Мама - {mother.name}");
            }
            if (father != null)
            {
                Console.WriteLine($"Папа - {father.name}");
            }

            Console.WriteLine("--------------");

            var childrenOfPerents = new List<FamilyMember> { this };
            if (mother != null)
            {
                ChildrenOfPerents(mother, childrenOfPerents);
            }
            if (father != null)
            {
                ChildrenOfPerents(father, childrenOfPerents);
            }
            Console.WriteLine("Братья и сестры:");
            foreach (var child in childrenOfPerents)
            {
                if (!child.Equals(this))
                {
                    if (child.Sex == Gender.Male)
                    {
                        Console.WriteLine($"Брат - {child.name}");
                    }
                    else
                    {
                        Console.WriteLine($"Сестра - {child.name}");
                    }
                }
            }

            Console.WriteLine("--------------");

            Console.WriteLine("Партнеры:");
            var partners = this.Partners();
            foreach (var partner in partners)
            {
                if (partner.Sex == Gender.Male)
                {
                    Console.WriteLine($"Муж - {partner.name}");
                }
                else
                {
                    Console.WriteLine($"Жена - {partner.name}");
                }
            }

            Console.WriteLine("--------------");

            Console.WriteLine("Дети:");
            foreach (var child in this.children)
            {
                if (child.Sex == Gender.Male)
                {
                    Console.WriteLine($"Сын - {child.name}");
                }
                else
                {
                    Console.WriteLine($"Дочь - {child.name}");
                }
            }

            Console.WriteLine("--------------");
        }
        private static List<FamilyMember> ChildrenOfPerents(FamilyMember perent, List<FamilyMember> children)
        {
            if (perent != null)
            {
                foreach (var child in perent.children)
                {
                    if (!children.Contains(child))
                    {
                        children.Add(child);
                    }
                }
            }
            return children;
        }
        private List<FamilyMember> Partners()
        {
            var partners = new List<FamilyMember>();
            if (sex == Gender.Male)
            {
                foreach (var child in this.children)
                {
                    if (child.mother != null)
                    {
                        if (!partners.Contains(child.mother))
                        {
                            partners.Add(child.mother);
                        }
                    }
                }
            }
            else
            {
                foreach (var child in this.children)
                {
                    if (child.father != null)
                    {
                        if (!partners.Contains(child.father))
                        {
                            partners.Add(child.father);
                        }
                    }
                }
            }
            return partners;
        }
    }
}
