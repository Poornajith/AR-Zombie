using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;



public class SpawnableManager : MonoBehaviour
{
    [SerializeField]ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField] GameObject spawnablePrefab;
    [SerializeField] GameObject tower;

    Camera arCam;
    GameObject spawnedObject;

    bool isTowerPlaced = false;

    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0) return;

        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if(m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null ) 
            {
                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Spawnable")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else if (hit.collider.gameObject == tower)
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else
                    {
                        if(isTowerPlaced)
                        {
                            SpawnPrefab(m_Hits[0].pose.position);
                        }
                        else
                        {
                            Instantiate(tower, m_Hits[0].pose.position, Quaternion.identity);
                            isTowerPlaced = true;
                        }
                    }
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null )
            {
                spawnedObject.transform.position = m_Hits[0].pose.position;
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended) { spawnedObject = null; }
        }
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }
}
