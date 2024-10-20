using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* William Smith
 * Destroy Goblins on interaction with entity
 * 10/18/24
 */

public class Spawn_Goblin : MonoBehaviour
{
    public float secondsBetweenSpawn = 5.0f;
    public float secondsSinceLast = 0.0f;
    private float secondsSinceFirst = 0.0f;
    public float maxStopSpawn = 20.0f;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (prefab != null) //If null don't inc
        {
            secondsSinceLast += Time.deltaTime; //used for reset counter to create more goblins
            secondsSinceFirst += Time.deltaTime; //used for last goblin spawned
        }

        if (secondsSinceLast >= secondsBetweenSpawn && secondsSinceFirst <= maxStopSpawn) //condition error checking
        {
            Instantiate(prefab, transform.position, transform.rotation); //create goblin
            secondsSinceLast = 0; //var reset
        }
        else if (secondsSinceFirst >= maxStopSpawn) //null val
        {
            Debug.Log("Goblins have stopped spawning"); //After maxStopSawn time
            prefab = null;
        }
        else //blank else (could debug val here)
        {
        }
    }
}
