using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDestroyGoblin : MonoBehaviour
{
    Renderer m_Renderer;
    void Start()
    {
        m_Renderer = GetComponent<Renderer>(); //Renderer is the easiest way besides camera collision triggers
    }

    void Update()
    {
        //If object not rendered within frame of camera the entity gets despawned (going off camera)
        if (!m_Renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
