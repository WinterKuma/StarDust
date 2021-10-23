
public class BuffInfo
{
    public enum BuffType
    { 
        Burn,
        Poisoning,
        Dark,
        Bind,
        Silence,
        Petrify,
        Stun
    }

    public BuffType type { get; private set; }
    public int duration { get; private set; }
    public int count = 0;
}
