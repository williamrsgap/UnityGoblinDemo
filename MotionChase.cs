using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionChase : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 0.2f; // Distance to move each second
    public float stopRadius = 0.1f; // Stop when in this range of target

    public string tagname = "Player";   // Look for Player Tag

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject g = collider.gameObject; // Get object that hit my trigger
        if (g.CompareTag("Player"))
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
                rb.position += del * speed * Time.deltaTime;
            }
        }
    }

    // Invoked when something leaves range of my trigger
    void OnTriggerExit2D(Collider2D collider)
    {
        GameObject g = collider.gameObject; // Get object that hit my trigger
        if (g.CompareTag("Player"))
        {
            Debug.Log("Player out of range");
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        GameObject g = collider.gameObject; // Get object that hit my trigger
        if (g.CompareTag("Player"))
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
                rb.position += del * speed * Time.deltaTime;
            }
        }
    }
}
