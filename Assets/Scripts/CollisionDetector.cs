using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private GameUI gameUI;

    void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Obstacle"))
        {
            gameUI.TriggerGameOver("💥 اصطدمت بسيارة!");
        }
    }
}
