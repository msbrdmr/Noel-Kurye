using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float speed; // Speed at which the clouds move
    public float screenWidth; // Width of the screen in world units
    public float height; // Height at which the clouds should be displayed
    public GameObject cloudPrefab; // Prefab of the cloud object
    public int numClouds; // Number of clouds to instantiate

    void Start()
    {
        // Instantiate the required number of clouds
        for (int i = 0; i < numClouds; i++)
        {
            // Set the starting position of the clouds
            GameObject cloud = Instantiate(cloudPrefab, new Vector3(Random.Range(-screenWidth / 2, screenWidth / 2), height, 0), Quaternion.identity);
            
        }
    }
}
