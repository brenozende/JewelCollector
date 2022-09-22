using System.Collections;

namespace JewelCollector;

/// <summary>
/// Classe que representa a entidade Robô.
/// Tem os atributos energia e um Array de itens, referente à sacola do robô.
/// </summary>
public class Robot : Entity
{
    public int energy = 5;
    public ArrayList itens;

    /// <summary>
    /// Construtor do robô, que inicializa a sacola vazia.
    /// </summary>
    public Robot() {
        this.itens = new ArrayList();
    }

    public override string ToString() {
        return "ME";
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

    /// <summary>
    /// Método que imprime na tela as informações do robô, como: 
    /// Total de itens na sacola
    /// Total de pontos referentes à pontuação das joias
    /// Quantidade de energia restante
    /// </summary>
    public void PrintInfos() {
        PrintJewelTotal();
        PrintTotalPoints();
        PrintEnergy();
    }


}
