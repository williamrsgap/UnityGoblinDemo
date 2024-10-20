using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredGoblin : MonoBehaviour
{
    public string tagname = "Goblin";  // Type of objects I collect

    // Called by game engine when collider on this object hits another collider
    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject g = collision.gameObject; // Get reference to obj
        Debug.Log("Hit " + g.name); // Printlog for hits

        if (g.CompareTag(tagname))
        {
            Debug.Log("Hit a Goblin");
            GameObject.Destroy(g); // Collect it by removing it from the scene
        }
    }
}
