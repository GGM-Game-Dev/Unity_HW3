using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float Angle;
    public float RotationSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Angle = transform.transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        Angle += RotationSpeed;
        transform.localRotation = Quaternion.Euler(0, Angle, 0);
    }
}
