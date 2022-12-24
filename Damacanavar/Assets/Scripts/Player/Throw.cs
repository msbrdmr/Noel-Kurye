using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject throwObject;
    public LineRenderer directionLine;
    public float throwStrength = 10.0f;

    void Start()
    {
        // Set up the direction line
        directionLine.enabled = false;
        directionLine.positionCount = 2;
    }

    void OnMouseDown()
    {
        // Check if the mouse is over the player object
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10.0f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // if (GetComponent<BoxCollider2D>().bounds.Contains(worldPosition))
        // {
            // Start drawing the direction line
            directionLine.enabled = true;
        // }
    }

    void OnMouseUp()
    {
        // Stop drawing the direction line and throw the object
        directionLine.enabled = false;
        ThrowObject();
    }

    void Update()
    {
        if (directionLine.enabled)
        {
            // Update the position of the direction line
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            directionLine.SetPosition(0, transform.position);
            directionLine.SetPosition(1, worldPosition);
        }
    }

    void ThrowObject()
    {
        // Calculate the force to apply to the object
        Vector3 force = directionLine.GetPosition(1) - directionLine.GetPosition(0);
        force.Normalize();
        force *= throwStrength;

        // Instantiate the throw object and apply the force to it
        GameObject thrownObject = Instantiate(throwObject, transform.position, Quaternion.identity);
        thrownObject.SetActive(true);
        Rigidbody2D rb = thrownObject.GetComponent<Rigidbody2D>();
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
