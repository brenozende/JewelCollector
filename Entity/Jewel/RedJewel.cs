namespace JewelCollector;

/// <summary>
/// Classe do objeto joia vermelha. Possui valor = 100 referente à pontuação.
/// Sobrescreve o método ToString para imprimir seu "desenho" no mapa como "JR"
/// </summary>
public class RedJewel : Entity, Jewel
{
    public const int value = 100;
    public override string ToString() {
        return "JR";
    }
    public int GetValue() {
        return value;
    }
}
