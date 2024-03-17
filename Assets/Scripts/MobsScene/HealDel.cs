using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            Del();
        }
    }

    private void Del()
    {
        Destroy(gameObject);
    }
}

