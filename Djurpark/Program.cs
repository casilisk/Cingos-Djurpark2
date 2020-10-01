using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

class Program
{
    public List<Animal> zAnimal = new List<Animal>();

    string path = @"..\..\..\animalRegistry.txt";
    string deathPath = @"..\..\..\animalDeathRegistry.txt";


    static void Main()
    {
        new Program().Run();
    }

    private void Run()
    {
        TxtToList();
        CommandList();
    }

    private void CommandList()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose a service: Register | Add | Registry | Log | Terminate | Help | Exit");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "add":
                    Add();
                    break;

                case "terminate":
                    Terminate();
                    Console.ReadKey();
                    break;

                case "registry":
                    Registry();
                    Console.ReadKey();
                    break;

                case "log":
                    DeathLog();
                    Console.ReadKey();
                    break;

                case "sort":
                    Console.WriteLine("How would you like to sort: name, species, property");
                    string inputSort = Console.ReadLine().ToLower();
                    if(inputSort == "name")
                    {
                        Sort(zAnimal);
                        Console.ReadKey();
                    }
                    if(inputSort == "species")
                    {
                        SortSpeciesName(zAnimal);
                        Console.ReadKey();
                    }
                    if(inputSort == "property")
                    {
                        SortSpeciesProperty(zAnimal);
                        Console.ReadKey();
                    }
                    break;

                case "exit":
                    Console.WriteLine("Shutting off...");
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private void Sort(List<Animal> list)
    {
        int count, miniPos;
        count = list.Count;
        for (int i = 0; i < count - 1; i++)
        {
            miniPos = i;
            for (int j = i + 1; j < count; j++)
            {
                if (list[j].Name.CompareTo(list[miniPos].Name) < 0)
                {
                    miniPos = j;
                }
            }
            Animal temp = list[miniPos];
            list[miniPos] = list[i];
            list[i] = temp;
        }
    }

    private void SortSpeciesProperty(List<Animal> list)
    {
        Console.WriteLine("Pick the animal you want to sort by unique property: Tiger, Elephant or Owl.");
        string input = Console.ReadLine().ToLower();
        if (input == "tiger")
        {
            List<Tiger> tList = new List<Tiger>();
            foreach (Animal anim in zAnimal)
            {
                if (anim is Tiger)
                {
                    Tiger tempTig = anim as Tiger;
                    tList.Add(tempTig);
                }
            }
            int count, miniPos;
            count = tList.Count;
            for (int i = 0; i < count - 1; i++)
            {
                miniPos = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (tList[miniPos].Weight.CompareTo(tList[j].Weight) < 0)
                    {
                        miniPos = j;
                    }
                }
                Tiger temp = tList[miniPos];
                tList[miniPos] = tList[i];
                tList[i] = temp;
            }
            for (int k = 0; k < tList.Count; k++)
            {
                Console.WriteLine("ID: " + tList[k].Id + ", Species: " + tList[k] + ", Name: " + tList[k].Name + ", Weight: " + tList[k].Weight + ", Age: " + tList[k].Age);
            }
        }
        if (input == "owl")
        {
            List<Owl> oList = new List<Owl>();
            foreach (Animal anim in zAnimal)
            {
                if (anim is Owl)
                {
                    Owl tempOwl = anim as Owl;
                    oList.Add(tempOwl);
                }
            }
            int count, miniPos;
            count = oList.Count;
            for (int i = 0; i < count - 1; i++)
            {
                miniPos = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (oList[miniPos].Wingspan.CompareTo(oList[j].Wingspan) < 0)
                    {
                        miniPos = j;
                    }
                }
                Owl temp = oList[miniPos];
                oList[miniPos] = oList[i];
                oList[i] = temp;
            }
            for (int k = 0; k < oList.Count; k++)
            {
                Console.WriteLine("ID: " + oList[k].Id + ", Species: " + oList[k] + ", Name: " + oList[k].Name + ", Weight: " + oList[k].Weight + ", Age: " + oList[k].Age + ", Wingspan: " + oList[k].Wingspan + "cm");
            }
        }
        if (input == "elephant")
        {
            List<Elephant> eList = new List<Elephant>();
            foreach (Animal anim in zAnimal)
            {
                if (anim is Elephant)
                {
                    Elephant tempElp = anim as Elephant;
                    eList.Add(tempElp);
                }
            }
            int count, miniPos;
            count = eList.Count;
            for (int i = 0; i < count - 1; i++)
            {
                miniPos = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (eList[miniPos].TrunkLength.CompareTo(eList[j].TrunkLength) < 0)
                    {
                        miniPos = j;
                    }
                }
                Elephant temp = eList[miniPos];
                eList[miniPos] = eList[i];
                eList[i] = temp;
            }
            for (int k = 0; k < eList.Count; k++)
            {
                Console.WriteLine("ID: " + eList[k].Id + ", Species: " + eList[k] + ", Name: " + eList[k].Name + ", Weight: " + eList[k].Weight + ", Age: " + eList[k].Age + ", Trunk length: " + eList[k].TrunkLength + "cm");
            }
        }
    }

    private void SortSpeciesName(List<Animal> list)
    {
        Sort(zAnimal);
        Console.WriteLine("Pick the species you want to sort by: Tiger, Elephant or Owl.");
        string input = Console.ReadLine().ToLower();
        int count = 0;
        if (input == "owl")
        {
            foreach (Animal anim in zAnimal)
            {
                if (anim is Owl)
                {
                    Owl temp = anim as Owl;
                    Console.WriteLine("ID: " + zAnimal[count].Id + ", Species: " + zAnimal[count] + ", Name: " + zAnimal[count].Name + ", Weight: " + zAnimal[count].Weight + ", Age: " + zAnimal[count].Age + ", Wingspan: " + temp.Wingspan + "cm");
                }
                count++;
            }
        }
        if (input == "tiger")
        {
            foreach (Animal anim in zAnimal)
            {
                if (anim is Tiger)
                {
                    Tiger temp = anim as Tiger;
                    Console.WriteLine("ID: " + zAnimal[count].Id + ", Species: " + zAnimal[count] + ", Name: " + zAnimal[count].Name + ", Weight: " + zAnimal[count].Weight + ", Age: " + zAnimal[count].Age);
                }
                count++;
            }
        }
        if (input == "elephant")
        {
            foreach (Animal anim in zAnimal)
            {
                if (anim is Elephant)
                {
                    Elephant temp = anim as Elephant;
                    Console.WriteLine("ID: " + zAnimal[count].Id + ", Species: " + zAnimal[count] + ", Name: " + zAnimal[count].Name + ", Weight: " + zAnimal[count].Weight + ", Age: " + zAnimal[count].Age + ", Trunk length: " + temp.TrunkLength + "cm");
                }
                count++;
            }
        }
    }

    private void TxtToList()
    {
        StreamReader sr = new StreamReader(path);
        string text;
        while ((text = sr.ReadLine()) != null)
        {
            string[] parts = text.Split(' ');
            string species = parts[1];
            string id = parts[0];
            string name = parts[2];
            int age = int.Parse(parts[4]);
            int weight = int.Parse(parts[3]);
            if (species == "tiger")
            {
                Tiger t = new Tiger()
                {
                    Name = name,
                    Weight = weight,
                    Age = age,
                    Id = id
                };
                zAnimal.Add(t);
            }
            else if (species == "elephant")
            {
                int trunkLength = int.Parse(parts[5]);
                Elephant e = new Elephant()
                {
                    Name = name,
                    Weight = weight,
                    Age = age,
                    Id = id,
                    TrunkLength = trunkLength
                };
                zAnimal.Add(e);
            }
            else if (species == "owl")
            {
                int wingspan = int.Parse(parts[5]);
                Owl o = new Owl()
                {
                    Name = name,
                    Weight = weight,
                    Age = age,
                    Id = id,
                    Wingspan = wingspan
                };
                zAnimal.Add(o);
            }
        }
        sr.Close();
    }

    private void DeathLog()
    {
        StreamReader sr = new StreamReader(deathPath);
        string text;
        Console.WriteLine();
        while ((text = sr.ReadLine()) != null)
        {
            Console.WriteLine(text);
        }
        sr.Close();
    }

    private void ListToTxt()
    {
        StreamWriter sw = new StreamWriter(path);
        int count = 0;
        foreach (Animal anim in zAnimal)
        {
            if (anim is Owl)
            {
                Owl temp = anim as Owl;
                sw.WriteLine(zAnimal[count].Id + " owl " + zAnimal[count].Name + " " + zAnimal[count].Weight + " " + zAnimal[count].Age + " " + temp.Wingspan);
            }
            else if (anim is Tiger)
            {
                Tiger temp = anim as Tiger;
                sw.WriteLine(zAnimal[count].Id + " tiger " + zAnimal[count].Name + " " + zAnimal[count].Weight + " " + zAnimal[count].Age);
            }
            if (anim is Elephant)
            {
                Elephant temp = anim as Elephant;
                sw.WriteLine(zAnimal[count].Id + " elephant " + zAnimal[count].Name + " " + zAnimal[count].Weight + " " + zAnimal[count].Age + " " + temp.TrunkLength);
            }
            count++;
        }
        sw.Close();
    }

    private void Registry()
    {
        int count = 0;
        foreach (Animal anim in zAnimal)
        {
            if (anim is Owl)
            {
                Owl temp = anim as Owl;
                Console.WriteLine("ID: " + zAnimal[count].Id + ", Species: " + zAnimal[count] + ", Name: " + zAnimal[count].Name + ", Weight: " + zAnimal[count].Weight + ", Age: " + zAnimal[count].Age + ", Wingspan: " + temp.Wingspan + "cm");
            }
            else if (anim is Tiger)
            {
                Tiger temp = anim as Tiger;
                Console.WriteLine("ID: " + zAnimal[count].Id + ", Species: " + zAnimal[count] + ", Name: " + zAnimal[count].Name + ", Weight: " + zAnimal[count].Weight + ", Age: " + zAnimal[count].Age);
            }
            if (anim is Elephant)
            {
                Elephant temp = anim as Elephant;
                Console.WriteLine("ID: " + zAnimal[count].Id + ", Species: " + zAnimal[count] + ", Name: " + zAnimal[count].Name + ", Weight: " + zAnimal[count].Weight + ", Age: " + zAnimal[count].Age + ", Trunk length: " + temp.TrunkLength + "cm");
            }
            count++;
        }
    }

    private void Terminate()
    {
        Console.WriteLine("Pick out the ID of the animal you have to put down: ");
        Registry();
        StreamWriter sw = new StreamWriter(deathPath, true);
        Console.Write("Enter ID: ");
        string input = Console.ReadLine();
        for (int i = 0; i < zAnimal.Count; i++)
        {
            if (input == zAnimal[i].Id)
            {
                if (zAnimal[i] is Owl)
                {
                    Owl temp = zAnimal[i] as Owl;
                    sw.WriteLine("ID: " + zAnimal[i].Id + ", Species: " + zAnimal[i] + ", Name: " + zAnimal[i].Name + ", Weight: " + zAnimal[i].Weight + ", Age: " + zAnimal[i].Age + ", Wingspan: " + temp.Wingspan + "cm" + " Date of death: " + DateTime.Now.ToString());
                }
                else if (zAnimal[i] is Tiger)
                {
                    sw.WriteLine("ID: " + zAnimal[i].Id + ", Species: " + zAnimal[i] + ", Name: " + zAnimal[i].Name + ", Weight: " + zAnimal[i].Weight + ", Age: " + zAnimal[i].Age + " Date of death: " + DateTime.Now.ToString());
                }
                if (zAnimal[i] is Elephant)
                {
                    Elephant temp = zAnimal[i] as Elephant;
                    sw.WriteLine("ID: " + zAnimal[i].Id + ", Species: " + zAnimal[i] + ", Name: " + zAnimal[i].Name + ", Weight: " + zAnimal[i].Weight + ", Age: " + zAnimal[i].Age + ", Trunk length: " + temp.TrunkLength + "cm" + " Date of death: " + DateTime.Now.ToString());
                }
                zAnimal.RemoveAt(i);

                List<string> quotes = new List<string>();

                Random rnd = new Random();
                int randomQuote = rnd.Next(1, 14);
                string quote1 = "A murderer would never parade his crime in front of an open window.";
                string quote2 = "Not everybody is born a sadist, but you... you are beyond being a monster.";
                string quote3 = "Staring deep into its eyes, you watch as they fade and realize the blood on your hands.";
                Console.WriteLine("You injected the serum and end its bloodline here.");
                Console.WriteLine("Nobody commits a murder just for the experiment of committing it. Nobody except you.");
                Console.WriteLine("You started chopping off branches until you hit the root of the tree, its family tree that is.");
                Console.WriteLine("You'd be surprised how quick fur ignites. - Teemo");
                Console.WriteLine("We've all done things we're not proud of.");
                Console.WriteLine("Whoever fights with monsters should see to it that he does not become a monster in the process. And when he stares into the abyss for long enough, he will find that the abyss stares back.");
                Console.WriteLine("If I'd known it was harmless, I'd have killed it myself.");
                Console.WriteLine("Sometimes dead is better.");
                Console.WriteLine("Be afraid, be very afraid.");
                Console.WriteLine("Heeere's Johnny!");
                Console.WriteLine("How many animals had I already killed? There were those six that I knew about for sure.");
                Console.WriteLine("What other choice do you have when there's nobody else to trust?");
                //Döda inte djuren! :(
                //Ovan är massa film citat i sammanhängande tema.
            }
        }
        sw.Close();
        ListToTxt();
    }

    private void Add()
    {
        string name;
        int age;
        int weight;
        int trunkLength;
        int wingspan;
        string input;
        Console.WriteLine("What do you want to add?");
        input = Console.ReadLine().ToLower();
        while (true)
        {
            if (input == "tiger")
            {
                break;
            }
            if (input == "elephant")
            {
                break;
            }
            if (input == "owl")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please pick one of the allowed animals: Tiger, Elephant or Owl.");
                input = Console.ReadLine();
            }
        }
        Console.WriteLine("Pick a name for the animal: ");
        string inputName = Console.ReadLine().ToLower();
        while (!inputName.All(Char.IsLetter))
        {
            Console.WriteLine("Only letters allowed.");
            System.Threading.Thread.Sleep(1400);
            Console.WriteLine("Pick a name for the animal: ");
            inputName = Console.ReadLine().ToLower();
        }

        while (inputName.Contains(' '))
        {
            Console.WriteLine("\nNo spaces allowed.");
            System.Threading.Thread.Sleep(1400);
            Console.WriteLine("Pick a name for the animal: ");
            inputName = Console.ReadLine().ToLower();
        }
        while (inputName.Length < 3)
        {
            Console.WriteLine("Must be more than 3 characters.");
            System.Threading.Thread.Sleep(1400);
            Console.WriteLine("Pick a name for the animal: ");
            inputName = Console.ReadLine().ToLower();
        }
        StreamReader sr = new StreamReader(path);
        string text;
        while ((text = sr.ReadLine()) != null)
        {
            string[] parts = text.Split(' ');
            string species = parts[0];
            string nameCheck = parts[2];
            while (inputName == nameCheck && input == species)
            {
                Console.WriteLine("No duplicate names within the same species allowed.");
                System.Threading.Thread.Sleep(1400);
                Console.WriteLine("Pick a name for the animal: ");
                inputName = Console.ReadLine().ToLower();
            }
        }
        sr.Close();

        if (input == "tiger")
        {
            Random rnd = new Random();
            age = rnd.Next(1, 16);
            weight = rnd.Next(90, 310);
            name = inputName;

            string actualID;
            int calculatedId;
            string nameId = name.ToUpper();
            char chr1 = nameId[0];
            char chr2 = nameId[1];
            char chr3 = nameId[2];
            int chr1ToInt = (int)chr1;
            int chr2ToInt = (int)chr2;
            int chr3ToInt = (int)chr3;
            int value1 = chr1ToInt - 64;
            int value2 = chr2ToInt - 64;
            int value3 = chr3ToInt - 64;
            calculatedId = (value1 + value2 + value3) * weight;
            actualID = calculatedId.ToString();

            while (actualID.Length < 6)
            {
                int randNum = rnd.Next(1, 9);
                string temp = randNum.ToString();
                string temp2 = actualID;
                temp += temp2;
                actualID = temp;
            }

            Tiger t = new Tiger()
            {
                Age = age,
                Weight = weight,
                Name = name,
                Id = calculatedId.ToString()
            };
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(actualID + " tiger " + t.Name + " " + t.Weight + " " + t.Age);
            sw.Close();
            zAnimal.Add(t);
            Console.WriteLine("Added tiger: " + t.Name + " " + t.Weight + "kg " + t.Age + " years old" + " ID: " + actualID);
        }
        if (input == "elephant")
        {
            Random rnd = new Random();
            age = rnd.Next(1, 70);
            weight = rnd.Next(1000, 6000);
            trunkLength = rnd.Next(75, 250);
            name = inputName;
            string id = trunkLength.ToString();
            while (id.Length < 6)
            {
                id += trunkLength.ToString();
            }
            Elephant e = new Elephant()
            {
                Age = age,
                Weight = weight,
                TrunkLength = trunkLength,
                Name = name,
                Id = id
            };
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(id + " elephant " + e.Name + " " + e.Weight + " " + e.Age + " " + e.TrunkLength);
            sw.Close();
            zAnimal.Add(e);
            Console.WriteLine("Added elephant: " + e.Name + " " + e.Weight + "kg " + e.Age + " years old " + e.TrunkLength + "cm long trunk" + " ID: " + id);
        }

        if (input == "owl")
        {
            Random rnd = new Random();
            age = rnd.Next(1, 10);
            weight = rnd.Next(1, 4);
            wingspan = rnd.Next(95, 200);
            int id = rnd.Next(100, 999);
            name = inputName;
            string wingId = wingspan.ToString();
            while (wingId.Length < 3)
            {
                string temp = "0";
                string temp2 = wingId;
                temp += temp2;
                wingId = temp;
            }
            Owl o = new Owl()
            {
                Age = age,
                Weight = weight,
                Wingspan = wingspan,
                Name = name,
                Id = (wingId + id)
            };
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(wingspan.ToString() + id.ToString() + " owl " + o.Name + " " + o.Weight + " " + o.Age + " " + o.Wingspan);
            sw.Close();
            zAnimal.Add(o);
            Console.WriteLine("Added owl: " + o.Name + " " + o.Weight + "kg " + o.Age + " years old " + o.Wingspan + "cm long wingspan" + " ID: " + wingId + id);
        }
    }
}