using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ZombieMine : MonoBehaviour
{
    [SerializeField] public GameObject explosionEffect;
    [SerializeField] AudioSource bombBlip;
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
        if(other.gameObject.tag == "zombie")
        {
            Explode();    
            target.GetComponent<TowerToDefend>().deadZombieCount++;
        }
    }
    void Explode()
    {
        //create explosion effect
        GameObject mineExplosion = Instantiate(explosionEffect, transform.position, transform.rotation);

        // destroy bomb
        Destroy(gameObject);
        bombBlip.Play();

        //destroy explotion effect
        Destroy(mineExplosion, 1f); 
    }     
}
