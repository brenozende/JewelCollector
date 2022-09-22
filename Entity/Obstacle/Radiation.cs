namespace JewelCollector
{
    /// <summary>
    /// Classe que representa a radiação, presente no mapa a partir da fase 2.
    /// Sobrescreve o método ToString para imprimir seu "desenho" no mapa como "!!"
    /// </summary>
    public class Radiation : Entity
    {
        public override string ToString()
        {
            return "!!";
        }
    }
}