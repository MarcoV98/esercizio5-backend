using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<MenuItem> menu = new List<MenuItem>
        {
            new MenuItem("Coca Cola 150 ml", 2.50),
            new MenuItem("Insalata di pollo", 5.20),
            new MenuItem("Pizza Margherita", 10.00),
            new MenuItem("Pizza 4 Formaggi", 12.50),
            new MenuItem("Pz patatine fritte", 3.50),
            new MenuItem("Insalata di riso", 8.00),
            new MenuItem("Frutta di stagione", 5.00),
            new MenuItem("Pizza fritta", 5.00),
            new MenuItem("Piadina vegetariana", 6.00),
            new MenuItem("Panino Hamburger", 7.90)
        };

        List<MenuItem> selectedItems = new List<MenuItem>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============MENU==============");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {menu[i].Name} ({menu[i].Price:F2})");
            }
            Console.WriteLine($"{menu.Count + 1}: Stampa conto");
            Console.WriteLine("==============MENU==============");

            Console.Write("Inserisci il numero del cibo desiderato: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= menu.Count + 1)
            {
                if (choice == menu.Count + 1)
                {
                    ContoFinale(selectedItems);
                    break;
                }

                selectedItems.Add(menu[choice - 1]);
                Console.WriteLine($"{menu[choice - 1].Name} aggiunto.");
                Console.WriteLine("Premi un tasto per continuare");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Scelta non valida. Riprova.");
                Console.WriteLine("Premi un tasto per continuare");
                Console.ReadKey();
            }
        }
    }

    static void ContoFinale(List<MenuItem> selectedItems)
    {
        Console.Clear();
        Console.WriteLine("==============CONTO FINALE==============");
        double totalCost = 0;

        foreach (var item in selectedItems)
        {
            Console.WriteLine($"{item.Name} ({item.Price:F2})");
            totalCost += item.Price;
        }

        totalCost += 3.00; // Aggiunta del servizio al tavolo
        Console.WriteLine($"Servizio al tavolo (3.00)");
        Console.WriteLine($"Costo totale: {totalCost:F2}");
        Console.WriteLine("Grazie!");
    }
}

class MenuItem
{
    public string Name { get; set; }
    public double Price { get; set; }

    public MenuItem(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

