using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePage : MonoBehaviour
{
    public enum PageType
    { 
        InitPage,
        ManaPage,
        MainPage,
        EndPage,
        StayPage
    }

    public PageType pageType = PageType.EndPage;
    public GameManager manager;

    //턴 시작시 효과 리스트
    public List<object> pageOnEffectList;
    //턴 종료시 효과 리스트
    public List<object> pageOffEffectList;

    public virtual void Awake()
    {
        manager = GetComponent<GameManager>();
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }
}
