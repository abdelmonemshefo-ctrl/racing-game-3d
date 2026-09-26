using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject roadSegmentPrefab;
    public float segmentLength = 25f;
    public int initialSegments = 10;

    private Transform playerTransform;
    private float lastSpawnZ = 0f;
    private Queue<GameObject> roadSegments = new Queue<GameObject>();

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < initialSegments; i++)
        {
            SpawnRoadSegment(i * segmentLength);
        }
    }

    void Update()
    {
        if (playerTransform.position.z > lastSpawnZ - (segmentLength * 5f))
        {
            SpawnRoadSegment(lastSpawnZ + segmentLength);
        }

        if (roadSegments.Count > initialSegments + 2)
        {
            GameObject oldSegment = roadSegments.Dequeue();
            Destroy(oldSegment);
        }
    }

    void SpawnRoadSegment(float zPosition)
    {
        GameObject segment = Instantiate(roadSegmentPrefab);
        segment.transform.position = new Vector3(0f, 0f, zPosition);
        roadSegments.Enqueue(segment);
        lastSpawnZ = zPosition;
    }
}
