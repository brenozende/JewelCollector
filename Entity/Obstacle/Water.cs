namespace JewelCollector;

/// <summary>
/// Classe que representa o obstáculo água no mapa.
/// Sobrescreve o método ToString para imprimir seu "desenho" no mapa como "##"
/// </summary>
public class Water : Obstacle
{
    public override string ToString() {
        return "##";
    }
}
