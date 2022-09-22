namespace JewelCollector;

/// <summary>
/// Classe do objeto joia verde. Possui valor = 50 referente à pontuação.
/// Sobrescreve o método ToString para imprimir seu "desenho" no mapa como "JG"
/// </summary>
public class GreenJewel: Entity, Jewel
{
    public const int value = 50;
    public override string ToString() {
        return "JG";
    }
    public int GetValue() {
        return value;
    }
}
