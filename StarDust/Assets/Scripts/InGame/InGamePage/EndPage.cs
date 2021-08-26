using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPage : InGamePage
{
    public override void Awake()
    {
        base.Awake();
        pageType = PageType.EndPage;
    }
    public override void Enter()
    {
        foreach(object o in pageOffEffectList)
        {
            
        }
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
