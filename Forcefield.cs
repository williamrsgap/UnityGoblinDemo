using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{
    // Reference to the child prefab
    public GameObject childPrefab;
    public float maxStopSpawn = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Check input keypress
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Child spawn function ref
            SpawnChild();
        }
    }

    void SpawnChild()
    {
        // Instantiate the child at the parent's position
        GameObject child = Instantiate(childPrefab, transform.position, Quaternion.identity);

        // Set the parent of the child to this gameObject (the parent)
        child.transform.SetParent(transform);

        child.transform.localPosition = new Vector3(0, 0, 0); // 0, 0, 0 set to center of parent

        //DESTROY THE CHILD after maxStopSpawn time
        Destroy(child, maxStopSpawn);
    }
}
