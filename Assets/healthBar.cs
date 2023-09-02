using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    GameObject tower;
    int towerHealth;

    // Update is called once per frame
    void Update()
    {
        if (tower == null)
        {
            tower = GameObject.FindWithTag("defendable");            
        }
        if (tower != null)
        {
            towerHealth = tower.GetComponent<TowerToDefend>().towerHealth;
            transform.localScale = new Vector2(towerHealth/200f, transform.localScale.y);           
        }
    }
}
