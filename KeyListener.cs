namespace JewelCollector;

public class KeyListener
{
    public event EventHandler KeyPressed;
    
    protected virtual void OnKeyPressed(EventArgs e)
    {
        KeyPressed?.Invoke(this, e);
    }

}
