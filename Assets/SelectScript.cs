using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScript : MonoBehaviour
{
    public HeartMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void limbSelected()
    {
        menu.limbSelected();
    }
    public void chestSelected()
    {
        menu.chestSelected();
    }
}
