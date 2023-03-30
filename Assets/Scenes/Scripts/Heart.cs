using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private int Direction =1;
    public float Speed = 0.4f;
    public float MaxSize = 2f;
    public float MinSize = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        transform.localScale += new Vector3(Direction * Speed*Time.deltaTime, Direction * Speed *Time.deltaTime, Direction*Speed*Time.deltaTime);
        if (transform.localScale.x > MaxSize)
        {
            Direction = -1;
    
        }
        if (transform.localScale.x < MinSize)
        {
            Direction = 1;
        }
        
    }
}
