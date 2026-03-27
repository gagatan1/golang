
class Program
{
    static void Main()
    {
        // Car c = new Car();
        // c.carInfomation();
        // c.PrintInfo();
    }
}
class Vehicle  
{
    private bool cityRoads;
    public int wheels;
    public Vehicle()
    {
        wheels=0;
    }
    public Vehicle(int count)
    {
        wheels=count;
       
    }
    public void PrintInfo()
    {
        if (wheels>0)
        {
            Console.WriteLine("подойдет для города");
            cityRoads=true;
        }
        else
        {
            Console.WriteLine("не для города");
            cityRoads=false;
        }   
        
    }
    public int GetCount()
    {
        return wheels;
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
    private string categoria;

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
    public void categoriaCar()
    {
        if (weight>3500)
        {
            Console.WriteLine("машина категории С");
            categoria="C";
        }
        else
        {
            Console.WriteLine("машина категории B");
            categoria="B";
        }   
    }
}

class SportCar: Car
{
    private string brakingPerformance
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


    public string tyresSpeedLimit{ get; set; }
    public void tyresCategoria()
    {
        if (maxSpeed<201)
        {
            Console.WriteLine("машина отлично затормозит");
            brakingPerformance="класс A";
        }
        else if(maxSpeed<250)
        {
            Console.WriteLine("машина нормально затормозит");
            brakingPerformance="класс B";
        } 
        else if(maxSpeed<300)
        {
            Console.WriteLine("машина не очень затормозит");
            brakingPerformance="класс C";
        }   
    }
}