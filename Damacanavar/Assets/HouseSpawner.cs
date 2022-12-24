using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public Vector2 startpos;
    [SerializeField] private List<GameObject> houseList;
    [SerializeField] private List<GameObject> houseObjList;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float screenWidth;

    private void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        GameObject firstHouse = getHouse();
        GameObject newObj = Instantiate(firstHouse, startpos, Quaternion.identity);
        houseObjList = new List<GameObject>();
        houseObjList.Add(newObj);
        float scalePrev = firstHouse.GetComponent<SpriteRenderer>().bounds.size.x;
        Vector2 posPrev = startpos;

        for (int i = 1; i < 12; i++)
        {
            GameObject newHouse = getHouse();
            float newXPos = posPrev.x + scalePrev / 2 + (newHouse.GetComponent<SpriteRenderer>().bounds.size.x / 2);
            GameObject newObj1 = Instantiate(newHouse, new Vector2(newXPos, posPrev.y), Quaternion.identity);
            scalePrev = newHouse.GetComponent<SpriteRenderer>().bounds.size.x;
            posPrev = new Vector2(newXPos, posPrev.y);
            houseObjList.Add(newObj1);
        }
    }

    private void Update()
    {
        // Move all houses to the left
        foreach (GameObject house in houseObjList)
        {
            house.transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // Check if any house has moved out of the left side of the screen
        GameObject leftmostHouse = houseObjList[0];
        float leftmostXPos = leftmostHouse.transform.position.x - leftmostHouse.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        if (leftmostXPos < -screenWidth - leftmostHouse.GetComponent<SpriteRenderer>().bounds.size.x)
        {
            // Remove the leftmost house from the list
            houseObjList.RemoveAt(0);

            // Move the leftmost house to the right side of the screen
            float newXPos = houseObjList[houseObjList.Count - 1].transform.position.x + leftmostHouse.GetComponent<SpriteRenderer>().bounds.size.x + houseObjList[houseObjList.Count - 1].transform.localScale.x / 2;
            Vector2 newPos = new Vector2(newXPos, startpos.y);
            leftmostHouse.transform.position = newPos;

            // Add the leftmost house back to the list
            houseObjList.Add(leftmostHouse);
        }
    }

    private GameObject getHouse()
    {
        int ranindex = Random.Range(0, houseList.Count);
        return houseList[ranindex];
    }
}
