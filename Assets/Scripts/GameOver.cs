using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] public Text killCountText;
    int killCount;
    GameObject tower;
    int towerHealth;


    // Update is called once per frame
    void Update()
    {
        if(tower == null)
        {
            tower = GameObject.FindWithTag("defendable");
        }
        else
        {
            towerHealth = tower.GetComponent<TowerToDefend>().towerHealth;

            if(towerHealth <= 0)
            {
                killCount = tower.GetComponent<TowerToDefend>().deadZombieCount;
                gameOverPanel.SetActive(true);
                killCountText.text = killCount.ToString();
            }
        }
    }
}
