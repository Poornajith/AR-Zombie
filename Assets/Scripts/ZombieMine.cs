using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMine : MonoBehaviour
{
    public ParticleSystem explosion;

    private void OnTriggerEnter(Collider other)
    {
      
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        explosion.Play();
       // Destroy(gameObject);
    }

    
}
