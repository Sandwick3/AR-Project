using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationfix : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0); // Adjust based on the needed rotation
    }

}
