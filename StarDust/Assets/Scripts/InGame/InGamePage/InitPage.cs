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
        //Update()에서 UI 변동 시 혹은 게임 메니저에서 Scene 변경
        manager.SetPage(PageType.ManaPage);
    }
}
