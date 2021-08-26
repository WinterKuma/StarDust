using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPage : InGamePage
{
    public override void Awake()
    {
        base.Awake();
        pageType = PageType.InitPage;
    }
    public override void Enter()
    {
        manager.localPlayer.info.maxManaPoint = 0;
    }

    public override void Exit()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
