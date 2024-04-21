using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public float offset;

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
        if(player.transform.position.y > transform.position.y)
        {
        transform.position = new Vector3(transform.position.x, player.position.y + offset, transform.position.z);

        }

        }
    }
}
