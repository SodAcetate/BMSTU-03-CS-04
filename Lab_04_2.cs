using System;

namespace Lab_04_2
{   
    class Program
    {   

        class Car{
            public string Name {get; set;}
            public ushort ProductionYear {get; set;}
            public ushort MaxSpeed {get; set;}

            public Car(string name, ushort productionYear, ushort maxSpeed){
                Name = name;
                ProductionYear = productionYear;
                MaxSpeed = maxSpeed;
            }
            public void print(){
                Console.WriteLine($"{Name}\t{ProductionYear}г.\t{MaxSpeed}км/ч");
            }
        }

        class CarComparer : IComparer<Car>{
            int _mode = 0;
            public CarComparer(int mode){
                _mode = mode;
            }
            public int Compare(Car? x, Car? y){
                switch (_mode){
                    case 0:
                        return string.Compare(x.Name,y.Name);
                    case 1:
                        if (x.ProductionYear == y.ProductionYear) return 0;
                        else if (x.ProductionYear > y.ProductionYear) return 1;
                        else return -1;
                    case 2:
                        if (x.MaxSpeed == y.MaxSpeed) return 0;
                        else if (x.MaxSpeed > y.MaxSpeed) return 1;
                        else return -1;
                }
                return 0;
            }
        }
        static void Main(string[] args)
        {

            Car[] testArray = {new Car("Лада",1999,1000),
                                new Car("Мерс",1025,542),
                                new Car("Бэха",1568,300),
                                new Car("Ламба",2048,2048),
                                new Car("Тойота",1917,3689)};

            Console.WriteLine("Изначальный массив:");
            foreach (Car element in testArray){
                element.print();
            }
            Console.WriteLine();
            
            CarComparer testComparer = new CarComparer(0);
            Array.Sort(testArray,testComparer);

            Console.WriteLine("Сортировка по названию:");
            foreach (Car element in testArray){
                element.print();
            }
            Console.WriteLine();

            testComparer = new CarComparer(1);
            Array.Sort(testArray,testComparer);

            Console.WriteLine("Сортировка по году выпуска:");
            foreach (Car element in testArray){
                element.print();
            }
            Console.WriteLine();

            testComparer = new CarComparer(2);
            Array.Sort(testArray,testComparer);

            Console.WriteLine("Сортировка максимальной скорости:");
            foreach (Car element in testArray){
                element.print();
            }
            Console.WriteLine();

        }
    }
}