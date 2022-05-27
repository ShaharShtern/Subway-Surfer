using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopModelTransform : MonoBehaviour
{
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = new Vector3 (0, -1, 0);
    }
}
