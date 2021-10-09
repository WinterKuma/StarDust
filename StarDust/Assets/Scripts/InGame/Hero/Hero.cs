using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public HeroInfo info;
    public bool isActive;

    private void Awake()
    {
        info = GetComponent<HeroInfo>();
        info.SetState();
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
