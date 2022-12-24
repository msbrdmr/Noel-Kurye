using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetType() == typeof(UnityEngine.BoxCollider2D) )
        {
            Debug.Log("Chimney!");
        }

    }
    
}
