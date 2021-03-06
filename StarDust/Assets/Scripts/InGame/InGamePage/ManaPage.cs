using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPage : InGamePage
{
    public override void Awake()
    {
        base.Awake();
        pageType = PageType.ManaPage;
    }

    public override void Enter()
    {
        if(manager.localPlayer.info.maxManaPoint < manager.localPlayer.info.infoManaLimit)
        {
            ++manager.localPlayer.info.maxManaPoint;
        }
        manager.localPlayer.info.manaPoint = manager.localPlayer.info.maxManaPoint;
        manager.localPlayer.info.movePoint = manager.localPlayer.info.infoMovePoint;
        StartCoroutine(Delay());
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
        //manager.SetPage(PageType.MainPage);
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.0f);
        manager.SetPage(PageType.MainPage);
    }
}
