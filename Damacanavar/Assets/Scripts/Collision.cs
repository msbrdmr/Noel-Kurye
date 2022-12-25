using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] float multiplier = 15f;
    public ParticleSystem particle;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetType() == typeof(UnityEngine.BoxCollider2D))
        {
            Destroy(gameObject);
            FindObjectOfType<GoldUpdater>().UpdateGoldText();
        }

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity -= new Vector2(1, 0) * Time.fixedDeltaTime * multiplier;
    }

}
