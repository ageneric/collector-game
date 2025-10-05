using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 15f;
    [SerializeField] private float accelerationTime = 0.2f;
    [SerializeField] private float decelerationTime = 0.05f;
    private float stationaryThreshold = 0.01f;

    // Smoothing variables for each axis, required by Mathf.SmoothDamp
    private float velocityXSmoothing;
    private float velocityYSmoothing;
 
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get raw input for immediate response
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // --- MOVEMENT LOGIC ---
        Vector2 currentVelocity = rb.velocity;

        // Initial movement
        if (moveDirection.x != 0 && Mathf.Abs(currentVelocity.x) < stationaryThreshold)
        {
            currentVelocity.x = speed * moveDirection.x / (decelerationTime * 60);
        }
        if (moveDirection.y != 0 && Mathf.Abs(currentVelocity.y) < stationaryThreshold)
        {
            currentVelocity.y = speed * moveDirection.y / (decelerationTime * 60);
        }

        float targetVelocityX = moveDirection.x * speed;
        float targetVelocityY = moveDirection.y * speed;
        float smoothTimeX, smoothTimeY;

        smoothTimeX = (moveDirection.x != 0 && currentVelocity.x * moveDirection.x >= 0)
                ? accelerationTime
                : decelerationTime;

        smoothTimeY = (moveDirection.y != 0 && currentVelocity.y * moveDirection.y >= 0)
            ? accelerationTime
            : decelerationTime;

        float newVelocityX = Mathf.SmoothDamp(currentVelocity.x, targetVelocityX, ref velocityXSmoothing, smoothTimeX);
        float newVelocityY = Mathf.SmoothDamp(currentVelocity.y, targetVelocityY, ref velocityYSmoothing, smoothTimeY);
        Vector2 newVelocity = new Vector2(newVelocityX, newVelocityY);

        rb.velocity = (moveDirection.x == 0 && moveDirection.y == 0 && newVelocity.sqrMagnitude < stationaryThreshold)
            ? Vector2.zero
            : newVelocity;
    }
}