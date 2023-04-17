using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no_5_app
{
    
    interface IAnimal
    {
        string Name { get; set; }
        int Age { get; set; }

        void Eat();
        void Sleep();
        void Sound();
    }


    class Dog : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{Name}이(가) 식사를 합니다");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name}이(가) 잠에 듭니다");
        }

        public void Sound()
        {
            Console.WriteLine($"{Name}이(가) 멍멍");
        }
        
    }

    
    class Cat : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{Name}이(가) 식사를 합니다");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name}이(가) 잠에 듭니다");
        }

        public void Sound()
        {
            Console.WriteLine($"{Name}이(가) 애옭");
        }
    }

    class Horse : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{Name}이(가) 식사를 합니다");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name}이(가) 잠에 듭니다");
        }

        public void Sound()
        {
            Console.WriteLine($"{Name}이(가) 히히힣");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog() { Name = "갱얼쥐", Age = 8 };
            Console.WriteLine($"{dog.Name}는 {dog.Age}세");
            dog.Eat();
            dog.Sleep();
            dog.Sound();
            Console.WriteLine("\n");

            Cat cat = new Cat() { Name = "곰먐미", Age = 2 };
            Console.WriteLine($"{cat.Name}는 {cat.Age}세");
            cat.Eat();
            cat.Sleep();
            cat.Sound();
            Console.WriteLine("\n");

            Horse horse = new Horse() { Name = "마이리틀포니", Age = 16 };
            Console.WriteLine($"{horse.Name}는 {horse.Age}세");
            horse.Eat();
            horse.Sleep();
            horse.Sound();
            Console.WriteLine("\n");
        }
    }
}
