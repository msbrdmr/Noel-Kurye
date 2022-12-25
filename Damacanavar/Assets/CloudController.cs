using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float speed; // Speed at which the clouds move
    public float screenWidth; // Width of the screen in world units
    public float height; // Height at which the clouds should be displayed
    public List<GameObject> cloudPrefabs; // Prefab of the cloud object
    private Vector3 size;
    public int numClouds; // Number of clouds to instantiate

    private List<GameObject> clouds = new List<GameObject>(); // List to store all the instantiated clouds

    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        // Instantiate the required number of clouds
        for (int i = 0; i < numClouds; i++)
        {
            int rnd = Random.Range(0, 2);
            // Set the starting position of the clouds
            GameObject cloud = Instantiate(cloudPrefabs[rnd], new Vector3(10f * i - 8f, Random.Range(0f, 5f), 0), Quaternion.identity);
            clouds.Add(cloud); // Add the cloud to the list
            // cloud.SetActive(false);
        }
        size = clouds[0].GetComponent<SpriteRenderer>().bounds.size;

    }

    void Update()
    {
        Vector3 lastPos = clouds[clouds.Count - 1].transform.position;

        // Check for intersection between all pairs of clouds
        for (int i = 0; i < clouds.Count; i++)
        {
            var item = clouds[i];
            item.transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (item.transform.position.x <= -9 - size.x)
            {
                item.transform.position = new Vector3(lastPos.x + Random.Range(0.5f, size.x), item.transform.position.y, 0);
                clouds.Remove(item);
                clouds.Add(item);
                lastPos = item.transform.position;
                i--;
            }
        }




    }


}