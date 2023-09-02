using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackToTower : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 targetPos;
    public float speed = 50f;

    GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("defendable");
            targetPos = target.transform.position;
        }
        if (target != null)
        {
            targetPos = target.transform.position;
            Vector3 direction = targetPos - transform.position;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(targetPos);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        target.GetComponent<TowerToDefend>().currentZombieCount--;
    }
}
