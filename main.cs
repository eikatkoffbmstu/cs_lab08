using System;
using System.IO;
using System.Xml.Serialization;
using AnimalLibrary;

class main
{
    static void Main()
    {
        Animal cow = new Cow { Name = "Буренка", Country = "Россия", HideFromOtherAnimals = false };

        XmlSerializer serializer = new XmlSerializer(typeof(Cow));
        using (FileStream fs = new FileStream("animals.xml", FileMode.Create))
        {
            serializer.Serialize(fs, cow);
        }

        Console.WriteLine("XML файл с животным создан.");

        using (FileStream fs = new FileStream("animals.xml", FileMode.Open))
        {
            Animal deserializedAnimal = (Animal)serializer.Deserialize(fs);
            Console.WriteLine($"Имя: {deserializedAnimal.Name}, Страна: {deserializedAnimal.Country}, Любимая еда: {deserializedAnimal.GetFavouriteFood()}, Классификация: {deserializedAnimal.GetClassificationAnimal()}");
        }
    }
}
