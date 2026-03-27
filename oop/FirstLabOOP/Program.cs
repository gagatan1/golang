
class Program
{
    static void Main()
    {
        SportCar c = new SportCar();
        // c.carInfomation();
        c.SetCount(1);
        c.PrintInfo();
        
        c.weight=3520;
        c.categoriaCar();
    }
}
class Vehicle  
{
    private bool _cityRoads;
    public int wheels;
    public Vehicle()
    {
        wheels=0;
    }
    public Vehicle(int count)
    {
        wheels=count;
       
    }
    public virtual void PrintInfo()
    {
        if (wheels>0)
        {
            Console.WriteLine("подойдет для города");
            _cityRoads=true;
        }
        else
        {
            Console.WriteLine("не для города");
            _cityRoads=false;
        }   
        
    }
    public void GetCityRoads()
    {
        Console.WriteLine(_cityRoads);

        // return cityRoads;
    }
    public void SetCount(int value)
    {
        wheels = value;
    }
}






class Car: Vehicle
{
    public int weight;
    public string brand;
    private string _categoria;

    public Car() : base()
    {
        weight=1000;
        brand="Unknown";
    }
    public Car(int count,string name)
    {
        weight=count;
        brand=name;
    }


    public int Weight
    {
        get { return weight; }
        set{
            weight=value;
        }

    }
    public string Brand
    {
        get { return brand; }
        set{
            brand=value;
        }

    }

    public override void PrintInfo()
    {
        base.PrintInfo();  // Вызов родительского метода
        Console.WriteLine($"Количество колес: {wheels}");  // ← использование поля родителя
        Console.WriteLine($"Марка: {brand}, Вес: {weight}");
    }
    public void GetCategoria()
    {
        Console.WriteLine(_categoria);
    }
    public void categoriaCar()
    {
        if (weight>3500)
        {
            _categoria="C";
        }
        else
        {
            _categoria="B";
        }   
    }
}

class SportCar: Car
{

    public override void PrintInfo()
    {
        // Вызываем метод родительского класса Car
        base.PrintInfo();
        
        // Используем поля из всех классов
        Console.WriteLine($"Максимальная скорость: {maxSpeed} км/ч");
    }    
    private string _brakingPerformance
;
    public int maxSpeed;


    public SportCar() : base()
    {
        maxSpeed=200;
    }
    public SportCar(int count)
    {
        maxSpeed=count;
    }
    public void GetBrakingPerformance()
    {
        Console.WriteLine(_brakingPerformance);
    }


    public string tyresSpeedLimit{ get; set; }
    public void tyresCategoria()
    {
        if (maxSpeed<201)
        {
            Console.WriteLine("машина отлично затормозит");
            _brakingPerformance="класс A";
        }
        else if(maxSpeed<250)
        {
            Console.WriteLine("машина нормально затормозит");
            _brakingPerformance="класс B";
        } 
        else if(maxSpeed<300)
        {
            Console.WriteLine("машина не очень затормозит");
            _brakingPerformance="класс C";
        }   
    }
}