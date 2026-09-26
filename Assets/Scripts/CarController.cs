using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Movement")]
    public float maxSpeed = 200f;
    public float acceleration = 50f;
    public float rotationSpeed = 5f;
    public float laneWidth = 3.5f;

    private float currentSpeed = 0f;
    private float currentLane = 0f;
    private float horizontalInput = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        MoveForward();
        UpdateLanePosition();
    }

    void HandleInput()
    {
        horizontalInput = 0f;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            horizontalInput = touch.position.x < Screen.width * 0.5f ? -1f : 1f;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontalInput = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontalInput = 1f;
    }

    void MoveForward()
    {
        if (currentSpeed < maxSpeed)
            currentSpeed += acceleration * Time.fixedDeltaTime;
        else
            currentSpeed = maxSpeed;

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, currentSpeed);
    }

    void UpdateLanePosition()
    {
        if (horizontalInput != 0f)
        {
            currentLane += horizontalInput * rotationSpeed * Time.fixedDeltaTime;
            currentLane = Mathf.Clamp(currentLane, -1f, 1f);
        }

        Vector3 target = new Vector3(currentLane * laneWidth, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, Time.fixedDeltaTime * 5f);
    }

    public float GetSpeed() => currentSpeed;
}
