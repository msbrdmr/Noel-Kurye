using UnityEngine;
using System.Collections;
public class FlyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float smoothTime = 0.3f;
    public Vector2 screenBounds = new Vector2(10f, 5f);

    private Vector3 velocity = Vector3.zero;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 targetPosition = transform.position + new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        targetPosition = ClampToTopScreenBounds(targetPosition);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime);
    }

    private Vector3 ClampToTopScreenBounds(Vector3 position)
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(position);
        screenPosition.x = Mathf.Clamp(screenPosition.x, 0f, Screen.width);
        screenPosition.y = Mathf.Clamp(screenPosition.y, 0f, Screen.height);
        return mainCamera.ScreenToWorldPoint(screenPosition);
    }


}
