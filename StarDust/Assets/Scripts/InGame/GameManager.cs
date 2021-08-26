using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InGamePage.PageType currentPage = InGamePage.PageType.EndPage;
    private Dictionary<InGamePage.PageType, InGamePage> pages = new Dictionary<InGamePage.PageType, InGamePage>();

    public Hero localPlayer;

    private void Awake()
    {
        pages[InGamePage.PageType.ManaPage] = GetComponent<ManaPage>();
        pages[InGamePage.PageType.MainPage] = GetComponent<MainPage>();
        pages[InGamePage.PageType.EndPage] = GetComponent<EndPage>();

        foreach(InGamePage page in pages.Values)
        {
            page.enabled = false;
        }
        SetPage(currentPage);
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
}
