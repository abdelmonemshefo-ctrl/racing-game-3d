using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public UnityEngine.UI.Button restartButton;

    private CarController carController;
    private float score = 0f;
    private bool gameOver = false;

    void Start()
    {
        carController = GameObject.FindGameObjectWithTag("Player").GetComponent<CarController>();
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        restartButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        });
    }

    void Update()
    {
        if (gameOver) return;

        float speed = carController.GetSpeed();
        speedText.text = "السرعة: " + Mathf.Round(speed) + " كم/س";

        score += Time.deltaTime * (speed / 12f);
        scoreText.text = "النقاط: " + Mathf.Floor(score).ToString();
    }

    public void TriggerGameOver(string message)
    {
        gameOver = true;
        Time.timeScale = 0f;

        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        gameOverText.text = message + "\nالنقاط: " + Mathf.Floor(score).ToString();
    }
}
