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

    //�� ���۽� ȿ�� ����Ʈ
    public List<object> pageOnEffectList;
    //�� ����� ȿ�� ����Ʈ
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
