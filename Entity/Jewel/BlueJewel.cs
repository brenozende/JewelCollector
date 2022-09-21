namespace JewelCollector;

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
