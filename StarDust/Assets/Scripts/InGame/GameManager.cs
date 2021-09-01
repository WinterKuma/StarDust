using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private InGamePage.PageType currentPage = InGamePage.PageType.InitPage;
    private Dictionary<InGamePage.PageType, InGamePage> pages = new Dictionary<InGamePage.PageType, InGamePage>();

    public Text movePointText;
    public Button turnEndButton;

    public GameObject[,] field = new GameObject[8, 8];
    public Hero localPlayer;


    private void Awake()
    {
        pages[InGamePage.PageType.InitPage] = GetComponent<InitPage>();
        pages[InGamePage.PageType.ManaPage] = GetComponent<ManaPage>();
        pages[InGamePage.PageType.MainPage] = GetComponent<MainPage>();
        pages[InGamePage.PageType.EndPage] = GetComponent<EndPage>();
        pages[InGamePage.PageType.StayPage] = GetComponent<StayPage>();

        foreach(InGamePage page in pages.Values)
        {
            page.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetPage(currentPage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPage(InGamePage.PageType setPageType)
    {
        pages[currentPage].Exit();
        pages[currentPage].enabled = false;
        currentPage = setPageType;
        pages[currentPage].enabled = true;
        pages[currentPage].Enter();
    }

    public void TurnEnd()
    {
        SetPage(InGamePage.PageType.EndPage);
    }
}
