using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* William Smith
 * Basically is the motion chase however has a negitive speed which allows it to run away from the player
 * 10/4/24
 */

public class MotionFlee : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed = 0.2f; // Distance to move each second
    public float stopRadius = 0.1f; // Stop when in this range of target

    public string tagname = "Player";   // Look for Player Tag

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get Player reference for gameobject
        GameObject g = GameObject.FindWithTag(tagname);

        // Tag Checking for Player
        if (g != null)
        {
            // Get its Rigidbody2D component
            Rigidbody2D trb = g.GetComponent<Rigidbody2D>();

            // New vector with difference between positions of target and myself
            Vector2 del = trb.position - rb.position;

            if (del.magnitude > stopRadius) // Only move when outside stop radius of target
            {
                // Normalize to have total magnitude 1
                del.Normalize();

                // Move by that amount normalized by desired speed and frame rate
                // Uses Negative Speed for a flee function
                rb.position += del * -speed * Time.deltaTime;
            }
        }
    }
}
