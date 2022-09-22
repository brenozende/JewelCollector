namespace JewelCollector;

/// <summary>
/// Classe que representa o obstáculo árvore no mapa.
/// Sobrescreve o método ToString para imprimir seu "desenho" no mapa como "$$"
/// </summary>
public class Tree : Obstacle
{
    public override string ToString() {
        return "$$";
    }
}
