namespace JewelCollector;

/// <summary>
/// Classe que representa o objeto de um caminho aberto no mapa.
/// Sobrescreve o método ToString para imprimir seu "desenho" no mapa como "--"
/// </summary>
public class OpenPath : Entity
{
    public override string ToString() {
        return "--";
    }
}
