using UnityEngine;

public class Buff
{
    BuffInfo info;

    public virtual void OnBuff()
    {
        Debug.LogFormat("OnBuff() type:{0} duration:{1}", info.type, info.duration);
        info.count = info.duration;
    }

    public virtual void BuffEffect()
    {
        Debug.LogFormat("BuffEffect() type:{0}", info.type);
        if(--info.count == 0)
        {
            OffBuff();
        }
    }

    public virtual void OffBuff()
    {
        Debug.LogFormat("OffBuff() type:{0} count:{1}", info.type, info.count);
    }
}
