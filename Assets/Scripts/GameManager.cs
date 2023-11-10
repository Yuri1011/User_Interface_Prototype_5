using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public List<GameObject> targets;
    private float spawnRate;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameWinText;
    private float timePassed;
    private bool timerRunning = true;
    public Button restartButton;
    public GameObject titleScreen;
    public int finalScore = 77;
    private GameObject backgroundAudio;
    void Start() {
        backgroundAudio = GameObject.Find("BackgroundMusic");
        backgroundAudio.GetComponent<AudioSource>();
    }
    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    IEnumerator StartTimer() {
        while (timerRunning) { // Изменено условие выполнения цикла таймера
            yield return new WaitForSeconds(1f); // 1 second at a time
            timePassed--;
            // Обновление текста на экране с отображением времени
            timeText.text = "Time: " + timePassed.ToString("F0") + "s";
            if (timePassed == 0f && score != finalScore) {
                // Когда время закончится, активируйте текст окончания игры
                gameOverText.gameObject.SetActive(true);
                backgroundAudio.SetActive(false);
                timerRunning = false; // Останавливаем таймер
                restartButton.gameObject.SetActive(true);
            } else if (score == finalScore) {
                gameWinText.gameObject.SetActive(true);
                backgroundAudio.SetActive(false);
                timerRunning = false; // Останавливаем таймер
                restartButton.gameObject.SetActive(true);
            }
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty) {
        switch (difficulty) {
            case 1:
                timePassed = 50.0f;
                spawnRate = 1.5f;
                break;
            case 2:
                timePassed = 65.0f;
                spawnRate = 1.0f;
                break;
            case 3:
                foreach (GameObject target in targets) {
                    target.GetComponent<Target>().minSpeed = 17.0f;
                }
                timePassed = 80.0f;
                spawnRate = 0.5f;
                break;
        }
        
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        StartCoroutine(StartTimer());
    }

    void Update(){
    }
}
