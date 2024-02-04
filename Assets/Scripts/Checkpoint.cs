using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public float threshold;

    public void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            Debug.Log("You Dead.");
            transform.position = new Vector3(-10.44f, 0.78f, 0f);
        }
    }
}
