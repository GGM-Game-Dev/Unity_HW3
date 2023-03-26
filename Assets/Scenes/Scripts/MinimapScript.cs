using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    public Transform player;

    //Called after Update and FixedUpdate
    private void LateUpdate()
    {
        //Minimap Follow our player
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //Rotate with player
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
