using System;
using System.Collections.Generic;
namespace Simulator
{
    abstract class Animal
    {
        public string name;
        public int age;
        public int satiety;
        public int garbage;
        public bool isHappy;
        public abstract void move();
        public abstract void eat();
        public void GetInfo()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age} Сытость: {satiety} Грязность: {garbage} Счастье{isHappy}");
        }
        public void hungry()
        {
            this.satiety = this.satiety - 1;
        }

        

    }
    interface Ilitter
    {

        public void litter();
    }
    class Dog : Animal, Ilitter

        {
            public int walkingRate;
            public Dog(string name)
            {
                this.name = name;
                this.age = 1;
                this.satiety = 2;
                this.garbage = 0;
                this.walkingRate = 1;
                isHappy = true;

            }
            public int eyes = 2;

            public int paws = 4;

            public override void move()
            {
                Console.WriteLine("Топ-топ");
            }
            public override void eat()
            {
                this.satiety = this.satiety + 1;
            }

            public void litter()
            {
                this.garbage = this.garbage + 1;
            }
            public void Walk()
            {
                move();
                this.walkingRate = this.walkingRate + 1;
            }



        }

        class Owl : Animal, Ilitter

        {
            
            public Owl(string name)
            {
                this.name = name;
                this.age = 1;
                this.satiety = 2;
                this.garbage = 0;
                isHappy = true;


            }
            public int eyes = 2;
            public int wings = 2;
            public int paws = 2;

            public override void move()
            {
                Console.WriteLine("*Летит*");
            }
            public override void eat()
            {
                this.satiety = this.satiety - 1;
            }
            public void litter()
            {
                this.garbage = this.garbage + 1;
            }
        }

        class Lizard : Animal, Ilitter
        {
            
            public int eyes = 2;
            public int limbs = 4;

            public override void move()
            {
                Console.WriteLine("*Ползет*");
            }
            public override void eat()
            {
                this.satiety = this.satiety - 1;
            }
            public void litter()
            {
                this.garbage = this.garbage + 1;
            }
            public Lizard(string name)
            {
                this.name = name;
                this.age = 1;
                this.satiety = 2;
                this.garbage = 0;
                isHappy = true;


            }
        }



        static class ZooShop
        {

            public static void CreateDog(List<Animal> list, string animal)
            {
                list.Add(new Dog(animal));


            }
            public static void CreateOwl(List<Animal> list, string animal)
            {
                list.Add(new Owl(animal));


            }
            public static void CreateLizard(List<Animal> list, string animal)
            {
                list.Add(new Lizard(animal));


            }
        }

            class Owner
        {
            public string name;
            public Owner(string name)
            {
                this.name = name;
            }

            public void cleaning(Animal animal)
            {
                animal.garbage = animal.garbage - 1;
            }
            public void feeding(Animal animal)
            {
                animal.eat();
            }
            public void toWalk(Animal animal)
            {
                animal.move();
            }


        }

        class Program
        {
            static void Main(string[] args)
            {


                List<Animal> Animals = new List<Animal>();
                Owner Ivan = new Owner("Ivan");
                while (true)
                {
                    Console.WriteLine("Что бы вы хотели сделать? 1-завести новое животное, 2-действия с имеющимися животными");
                    int x = Convert.ToInt32(Console.ReadLine());
                    switch (x)
                    {
                        case 1:
                            Console.WriteLine("Какое животное вы бы хотели создать 1-Собака, 2-Сова, 3-Ящерица");
                            int y = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите имя");
                            string name = Console.ReadLine();
                            switch (y)
                            {
                                case 1:
                                    ZooShop.CreateDog(Animals, name);
                                    Console.WriteLine($"Собака {name} заведена!\n");
                                    break;
                                case 2:
                                    ZooShop.CreateOwl(Animals, name);
                                    Console.WriteLine($"Сова {name} заведена!\n");
                                    break;
                                case 3:
                                    ZooShop.CreateLizard(Animals, name);
                                    Console.WriteLine($"Ящерица {name} заведена!\n");
                                    break;
                            }

                            break;
                        case 2:
                            Console.WriteLine("Что бы вы хотели с ним сделать? 1-посмотреть информацию 2-изменить информацию 3-покормить 4-убрать за питомцем 5-погулять с питомцем");
                            int zx = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("С каким из питомцев вы бы хотели это сделать? (1,2,3,4...)\n");
                            int i = Convert.ToInt32(Console.ReadLine());
                            switch (zx)
                            {
                                case 1:
                                    Animals[i - 1].GetInfo();
                                    break;

                                case 2:
                                    Console.WriteLine("Введите новое имя:");
                                    string newname = Console.ReadLine();
                                    Animals[i - 1].name = newname;
                                    Console.WriteLine($"Имя успешно изменено на {Animals[i - 1]}\n");
                                    break;

                                case 3:
                                    Ivan.feeding(Animals[i - 1]);
                                    Console.WriteLine($"Питомец {Animals[i - 1].name} успешно покушал!\n");
                                    break;
                                case 4:
                                    Ivan.cleaning(Animals[i - 1]);
                                    Console.WriteLine($"Хозяин{Ivan.name} поубирал за  {Animals[i - 1].name}!\n");
                                    break;

                                case 5:
                                    
                                    Ivan.toWalk(Animals[i - 1]);
                                    Console.WriteLine($"Хозяин {Ivan.name} погулял с  {Animals[i - 1].name}!\n");
                                    break;

                            }
                            break;

                    }

                }
            }



        }
    
}
