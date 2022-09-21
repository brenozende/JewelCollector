namespace JewelCollector;

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
