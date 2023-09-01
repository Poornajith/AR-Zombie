using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMine : MonoBehaviour
{
    public GameObject explosionEffect;
    private void OnTriggerEnter(Collider other)
    {
        Explode();                    
    }
    void Explode()
    {
        //create explosion effect
        GameObject mineExplosion = Instantiate(explosionEffect, transform.position, transform.rotation);

        // destroy bomb
        Destroy(gameObject);

        //destroy explotion effect
        Destroy(mineExplosion, 1f); 
    }     
}
