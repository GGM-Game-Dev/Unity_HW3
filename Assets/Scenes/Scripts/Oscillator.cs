using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    public float Speed = 2f;
    private float range = Mathf.PI;
    private float from,to,direction,offset;
    // Start is called before the first frame update
    void Start()
    {
        from = transform.position.x+0.1f;
        to = transform.position.x + range-0.1f;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > to-1.4)
        {
            direction = -1;
        }
        else if (transform.position.x < from) 
        {
            direction = 1;
        }

        offset = (transform.position.x - from)*2;
        offset = Mathf.Clamp(offset,0.15f, Mathf.PI - 0.15f);
        offset = offset - (Mathf.PI / 2);
        offset = Mathf.Cos(offset);
        Debug.Log(transform.position.x);

        transform.position +=new Vector3(direction*Time.deltaTime*offset*Speed, 0, 0);

    }
}
