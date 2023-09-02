using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TowerToDefend : MonoBehaviour
{
    public int towerHealth;
    public Text towerHealthText;
    public GameObject towerHealthBar;
    public Vector3 towerposition;

    public GameObject zombiePrefab;
    public float minDistance = 0.5f;
    public float maxDistance = 3f;
    public int maxZombieCount = 10;
    public int currentZombieCount = 0;
    public int deadZombieCount = 0;
    public float radius = 3f;
   
    void Awake()
    {
        towerHealth = 200;
        towerposition = transform.position;
        StartCoroutine(Timer());

        if(towerHealthText == null)
        {
            towerHealthText = GameObject.Find("Canvas").transform.Find("health").GetComponent<Text>();          
        }

        towerHealthText.text = towerHealth.ToString();
        
    }

    private void Update()
    {
        if (towerHealth <= 0)
        {
            Time.timeScale = 0;                   
        }

        /*for(int i = 0; i < maxZombieCount; i++)
        {

        }*/
    }

    // Update is called once per frame
    

    private void OnTriggerEnter(Collider other)
    {
        towerHealth -= 20;
        towerHealthText.text = towerHealth.ToString();
    }

    IEnumerator Timer()
    {
        // Create a variable to store the time
        float timer = 0.0f;

        // Loop forever
        while (true)
        {
            // Wait for 2 seconds
            yield return new WaitForSeconds(2.0f);

            // Increment the timer
            timer += 2.0f;

            // Call the function
            
            if(currentZombieCount < maxZombieCount && timer >= 5f)
            {
                ZombieSpawn();
            }
        }
    }

    void ZombieSpawn()
    {
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        Vector3 position = new Vector3(randomPoint.x + transform.position.x + 1f, transform.position.y, randomPoint.y + transform.position.z + 1f);
        Instantiate(zombiePrefab, position, Quaternion.identity);
        currentZombieCount++;
    }

}
