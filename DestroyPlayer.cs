using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public string tagname = "Player";  // Type of objects I collect

    // Called by game engine when collider on this object hits another collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject g = collision.gameObject; // Get reference to object we hit
        Debug.Log("Hit " + g.name); // Print its name in the hierarchy (useful for debugging)

        if (g.CompareTag(tagname))
        {
            Debug.Log("Hit the player!");
            GameObject.Destroy(g); // Collect it by removing it from the scene
        }
    }
}
