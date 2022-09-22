namespace JewelCollector;

/// <summary>
/// Classe do objeto joia azul. Possui valor = 10 referente à pontuação.
/// Sobrescreve o método ToString para imprimir seu "desenho" no mapa como "JB"
/// </summary>
public class BlueJewel : Entity, Jewel
{
    public const int value = 10;
    public override string ToString() {
        return "JB";
    }

    public int GetValue() {
        return value;
    }
}
