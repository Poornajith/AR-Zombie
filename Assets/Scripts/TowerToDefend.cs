using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class TowerToDefend : MonoBehaviour
{
    public int towerHealth;
    public GameObject gameOverPanel;
    public Text towerHealthText;
    public Vector3 towerposition;
   
    void Awake()
    {
        towerHealth = 100;
        towerposition = transform.position;
        towerHealthText.text = towerHealth.ToString();
    }

    private void Update()
    {
        if (towerHealth <= 0)
        {
            gameOverPanel.SetActive(true);           
        }
    }

    // Update is called once per frame
    

    private void OnTriggerEnter(Collider other)
    {
        towerHealth -= 20;
        towerHealthText.text = towerHealth.ToString();
    }


}
