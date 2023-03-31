using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public GameObject gun;
    private bool visibility = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideWeapon() 
    {
        if (visibility)
        {
            gun.SetActive(false);
            visibility = false;
        }
        else 
        {
            gun.SetActive(true);
            visibility = true;
        }

    }
}
