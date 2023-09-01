using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBoomEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyParticleEffect", 2.0f * Time.deltaTime);
    }

    void DestroyParticleEffect()
    {
        // Destroy the particle effect
       Destroy(gameObject);
    }
}
