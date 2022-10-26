using System;
using System.Collections;

namespace Lab_04_3
{   
    class Program
    {

        static int IterationMode=0;
        static ushort FilterValue;

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

        class CarCatalog : IEnumerable{

            Car[] _cars;
            public CarCatalog(Car[] src){
                _cars = src;
            }
            public Car this[int i]{
                get => _cars[i];
            }
            IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();
            
            public IEnumerator<Car> GetEnumerator()
            {   
                for (int i = 0 ; i < _cars.Length ; i ++){
                    yield return _cars[i];
                }
            }
            public IEnumerable<Car> Reverse()
            {   
                for (int i = _cars.Length-1 ; i > -1 ; i --){
                    yield return _cars[i];
                }
            }
            public IEnumerable<Car> FilterYear(int year)
            {   
                for (int i = 0 ; i < _cars.Length ; i ++){
                    if (_cars[i].ProductionYear == year) yield return _cars[i];
                }
            }
            public IEnumerable<Car> FilterSpeed(int speed)
            {   
                for (int i = 0 ; i < _cars.Length ; i ++){
                    if (_cars[i].MaxSpeed == speed) yield return _cars[i];
                }
            }
            
        }

        static void Main(string[] args)
        {
            
            
            Car[] testArray = {new Car("Лада",1999,1000),
                                new Car("Мерс",1025,542),
                                new Car("Бэха",1568,300),
                                new Car("Ламба",2048,2048),
                                new Car("Тойота",1917,3689)};

            CarCatalog testCatalog = new CarCatalog(testArray);

            foreach (Car obj in testCatalog){
                obj.print();
            }
            Console.WriteLine();

            foreach (Car obj in testCatalog.Reverse()){
                obj.print();
            }
            Console.WriteLine();

            foreach (Car obj in testCatalog.FilterYear(1999)){
                obj.print();
            }
            Console.WriteLine();

            foreach (Car obj in testCatalog.FilterSpeed(300)){
                obj.print();
            }
            Console.WriteLine();

        }
    }
}