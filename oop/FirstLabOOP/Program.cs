using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Конструкторы
        Console.WriteLine("=== 1. Конструкторы ===\n");
        CircularList collection = new Collection();
        // Collection.
        collection.ShowAll();
        // Console.WriteLine("=== 1. Конструкторы ===\n");
        SimpleList list = new SimpleList(5);
        CircularList circular = new CircularList();
        Console.WriteLine("✓ Объекты созданы\n");

        // 2. Геттеры/сеттеры
        Console.WriteLine("=== 2. Геттеры/сеттеры ===\n");
        collection.SetMaxSize(10);
        Console.WriteLine($"MaxSize Collection: {collection.GetMaxSize()}");
        list.Category = "Список задач";
        circular.DefaultValue = 3.14;
        Console.WriteLine("✓ Геттеры/сеттеры работают\n");

        // 3. Методы
        Console.WriteLine("=== 3. Методы ===\n");
        collection.Add("Элемент1");
        list.Add("Элемент2");
        circular.Add("Элемент3");
        collection.ShowAll();
        list.ShowAll();
        circular.ShowAll();
        Console.WriteLine("✓ Методы работают\n");

        // 4. Полиморфизм
        Console.WriteLine("=== 4. Полиморфизм ===\n");
        Collection poly = new CircularList();
        poly.Add("Полиморфный элемент");
        poly.ShowAll(); // Вызовется метод CircularList
        Console.WriteLine("✓ Полиморфизм работает\n");

        // 5. Операторы
        Console.WriteLine("=== 5. Операторы ===\n");
        CircularList a = new CircularList();
        a.Add("A"); a.Add("B");
        CircularList b = new CircularList();
        b.Add("A"); b.Add("B"); b.Add("C");

        Console.WriteLine($"a > b (по размеру): {a > b}");
        Console.WriteLine($"a < b: {a < b}");
        Console.WriteLine($"a == b: {a == b}");
        Console.WriteLine($"a + b: {(a + b).Count} элементов");
        a++;
        Console.WriteLine($"a++: {a.Count} элементов");
        Console.WriteLine("✓ Операторы работают\n");

        // 6. Инкапсуляция
        Console.WriteLine("=== 6. Инкапсуляция ===\n");
        Console.WriteLine("❌ collection._maxSize - приватное поле");
        Console.WriteLine("❌ collection._items - защищенное поле");
        Console.WriteLine("❌ collection.Category - нет в базовом классе");
        Console.WriteLine("\n✅ Инкапсуляция соблюдена");
    }
}

/// Базовый класс - Коллекция объектов
class Collection
{
    private int _maxSize;
    
    protected List<string> _items;
    
    public Collection()
    {
        _maxSize = 100;  
        _items = new List<string>();
    }
    public Collection(int maxSize)
    {
        _maxSize = maxSize;
        _items = new List<string>();
    }
    public int GetMaxSize()
    {
        return _maxSize;
    }
    public void SetMaxSize(int value)
    {
        if (value > 0)
            _maxSize = value;
    }
    
    public virtual void Add(string item)
    {
        if (_items.Count >= _maxSize)
        {
            Console.WriteLine($"Ошибка: превышен максимальный размер коллекции ({_maxSize})");
            return;
        }
        _items.Add(item);
        Console.WriteLine($"Добавлен элемент: {item}");
    }
    
    public virtual void ShowAll()
    {
        Console.WriteLine($"Коллекция содержит {_items.Count} элементов (макс: {_maxSize}):");
        foreach (var item in _items)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
}

/// Наследник - Список (расширяет базовую коллекцию)
class SimpleList : Collection
{
    private string _category;
    public SimpleList() : base()
    {
        _category = "Общий";
    }
    
    public SimpleList(int maxSize) : base(maxSize)
    {
        _category = "Общий";
    }
    
    public string Category
    {
        get { return _category; }
        set { _category = value; }
    }
    
    public override void Add(string item)
    {
        base.Add(item);
        Console.WriteLine($"  Список [{_category}]: теперь {_items.Count} элементов");
    }
    public override void ShowAll()
    {
        Console.Write($"Список (категория: {_category}): ");
        base.ShowAll();
    }
    public int Count
    {
        get { return _items.Count; }
    }
    
    public string GetItem(int index)
    {
        if (index >= 0 && index < _items.Count)
            return _items[index];
        return null;
    }
}

/// Наследник - Кольцевой список (элементы зациклены)
class CircularList : SimpleList
{
    private double _defaultValue;
    
    private int _currentIndex;
    
    public CircularList() : base()
    {
        _defaultValue = 0;
        _currentIndex = 0;
    }
    
    public CircularList(int maxSize) : base(maxSize)
    {
        _defaultValue = maxSize;
        _currentIndex = 0;
    }
    
    public double DefaultValue { get; set; }
    public override void Add(string item)
    {
        base.Add(item);
        Console.WriteLine($"  Кольцевой список: элемент добавлен в кольцевую структуру");
    }
    
    public override void ShowAll()
    {
        Console.Write("Кольцевой список (зацикленная структура): ");
        if (_items.Count == 0)
        {
            Console.WriteLine("пуст");
            return;
        }
        
        for (int i = 0; i < _items.Count; i++)
        {
            Console.Write($"{_items[i]} ");
        }
        Console.WriteLine("→ (после последнего снова первый)");
    }
    
    // Дополнительный метод: кольцевой обход (3 полных цикла)
    public void ShowCircularTraversal()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("Нет элементов для кольцевого обхода");
            return;
        }
        
        Console.Write("Кольцевой обход (3 цикла): ");
        for (int step = 0; step < _items.Count * 3; step++)
        {
            Console.Write($"{_items[step % _items.Count]} ");
        }
        Console.WriteLine();
    }
    
    // ============ ОПЕРАТОРЫ ============
    
    public static CircularList operator +(CircularList a, CircularList b)
    {
        CircularList result = new CircularList();
        foreach (var item in a._items)
            result.Add(item);
        foreach (var item in b._items)
            result.Add(item);
        return result;
    }
    
    public static bool operator >(CircularList a, CircularList b)
    {
        if (a is null || b is null) return false;
        return a._items.Count > b._items.Count;
    }
    public static bool operator <(CircularList a, CircularList b)
    {
        if (a is null || b is null) return false;
        return a._items.Count < b._items.Count;
    }
    
    public static bool operator ==(CircularList a, CircularList b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;
        
        if (a._items.Count != b._items.Count)
            return false;
        
        for (int i = 0; i < a._items.Count; i++)
        {
            if (a._items[i] != b._items[i])
                return false;
        }
        return true;
    }
    
    public static bool operator !=(CircularList a, CircularList b)
    {
        return !(a == b);
    }
    
    public static CircularList operator ++(CircularList list)
    {
        list.Add("новый");
        return list;
    }
    
    public override bool Equals(object obj)
    {
        if (obj is CircularList other)
            return this == other;
        return false;
    }
    
    public override int GetHashCode()
    {
        return _items.Count.GetHashCode();
    }
}