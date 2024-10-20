using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* William Smith
 * Combines a player power (speed boost when holding f)
 * with player motion
 * Uses an axis system rather than a key system
 * Note: There is motion delay whenever tied to the rigid body rather than the sprite itself
 * 10/4/24
 */

public class MotionPlayerScript : MonoBehaviour
{
    //Speed var, speed is default 1
    public float vspeed = 1;
    public float boost = 1.05f;
    public float boost_frames = 5f;
    //Rigidbody var
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Replaces the need for 4 keyboard statements
        //Grabs the value for axis
        //Also uses Arrow Keys and WASD
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");

        //Vector for axis values
        Vector2 direction = new Vector2(dx, dy);
        //Normalize Direction
        direction.Normalize();
        //Move in a given direction
        if (Input.GetKey("f") && boost_frames > 0) //With speed boost
        {
            boost_frames -= Time.fixedDeltaTime; //Sub to time
            rb.position += direction * Time.deltaTime * (vspeed + boost); //Speed boost!
        }
        else //Without speed boost :(
        {
            rb.position += direction * Time.deltaTime * vspeed;
        }
    }
}
