using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* William Smith
 * Destroy Goblins on interaction with house
 * 10/4/24
 */

public class DestroyGoblin : MonoBehaviour
{
    public string tagname = "Goblin";  // Type of objects I collect

    // Called by game engine when collider on this object hits another collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject g = collision.gameObject; // Get reference to object we hit
        Debug.Log("Hit " + g.name); // Print its name in the hierarchy (useful for debugging)

        if (g.CompareTag(tagname))
        {
            Debug.Log("Hit a Goblin");
            GameObject.Destroy(g); // Collect it by removing it from the scene
        }
    }
}
