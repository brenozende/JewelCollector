using System.Collections;

namespace JewelCollector;

public class Robot : Entity
{
    public int energy = 5;
    public ArrayList itens;

    public Robot() {
        this.itens = new ArrayList();
    }

    public override string ToString() {
        return "ME";
    }
    public void MoveUp() {
        
    }
    public void MoveRight() {

    }
    public void MoveLeft() {

    }
    public void MoveDown() {

    }
    public void Collect() {

    }
    private void PrintJewelTotal() {
        int redJewelTotal = 0;
        int blueJewelTotal = 0;
        int greenJewelTotal = 0;
        foreach (Jewel item in this.itens)
        {
            if(typeof(RedJewel).IsInstanceOfType(item)) {
                redJewelTotal += 1;
            }
            if(typeof(BlueJewel).IsInstanceOfType(item)) {
                blueJewelTotal += 1;
            }
            if(typeof(GreenJewel).IsInstanceOfType(item)) {
                greenJewelTotal += 1;
            }
        }
        Console.WriteLine("Total Jewels: " + redJewelTotal + " Red Jewels, " + blueJewelTotal + 
        " Blue Jewels and " + greenJewelTotal + " Green Jewels");
    }
    private void PrintTotalPoints() {
        int totalPoints = 0;
        foreach (Jewel item in this.itens)
        {
            totalPoints += item.GetValue();
        }
        Console.WriteLine("Total Points: " + totalPoints);
    }
    private void PrintEnergy() {
        Console.WriteLine("Remaining Energy: " + this.energy);
    }
    public void PrintInfos() {
        PrintJewelTotal();
        PrintTotalPoints();
        PrintEnergy();
    }


}
