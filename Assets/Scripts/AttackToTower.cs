using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackToTower : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 targetPos;
    public float speed = 50f;

    public GameObject target;

    private void Awake()
    {       
        targetPos = target.transform.position;
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = targetPos - transform.position;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(targetPos);
    }

    private void OnTriggerEnter(Collider other)
    {
         Debug.Log("boom");
         Destroy(gameObject);       
    }
}
