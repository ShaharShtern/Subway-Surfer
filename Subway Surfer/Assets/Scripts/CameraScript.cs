using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    float offset;
    void Start()
    {
        offset = transform.position.z - player.position.z;
    }

    void Update()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y, player.position.z + offset);
    }
}
