using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ZombieMine : MonoBehaviour
{
    public GameObject explosionEffect;
    GameObject target;
    private void Awake()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("defendable");           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Explode();
        target.GetComponent<TowerToDefend>().deadZombieCount++;
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
