using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 150f;
    public float laneWidth = 3.5f;
    public float laneSwitchInterval = 2.5f;

    private int currentLane = 0;
    private float switchTimer;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        rb.freezeRotation = true;
        switchTimer = laneSwitchInterval;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);

        switchTimer -= Time.fixedDeltaTime;
        if (switchTimer <= 0f)
        {
            currentLane = Random.Range(-1, 2);
            switchTimer = laneSwitchInterval;
        }

        Vector3 target = new Vector3(currentLane * laneWidth, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, Time.fixedDeltaTime * 2.5f);
    }
}
