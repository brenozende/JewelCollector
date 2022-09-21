namespace JewelCollector;

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
