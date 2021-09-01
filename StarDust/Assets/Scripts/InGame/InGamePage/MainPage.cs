using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : InGamePage
{
    public override void Awake()
    {
        base.Awake();
        pageType = PageType.MainPage;
    }
    public override void Enter()
    {
        manager.turnEndButton.gameObject.SetActive(true);
        manager.localPlayer.isActive = true;
    }

    public override void Exit()
    {
        manager.turnEndButton.gameObject.SetActive(false);
        manager.localPlayer.isActive = false;
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
