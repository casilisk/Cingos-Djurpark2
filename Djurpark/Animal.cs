using System;

abstract class Animal
{
    private int age;
    private int weight;
    private string name;
    private string id;

    public int Age { get => age; set => age = value; }
    public string Name { get => name; set => name = value; }
    public int Weight { get => weight; set => weight = value; }
    public string Id { get => id; set => id = value; }
}
