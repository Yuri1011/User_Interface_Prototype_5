using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameWinText;
    private float timePassed;
    private bool timerRunning = true;
    public Button restartButton;
    public GameObject titleScreen;
    private int finalScore = 77;
    void Start() {

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
                timerRunning = false; // Останавливаем таймер
                restartButton.gameObject.SetActive(true);
            } else if (score == finalScore) {
                gameWinText.gameObject.SetActive(true);
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

    public void StarGame(int difficulty) {
        switch (difficulty) {
            case 1:
                timePassed = 50.0f;
                break;
            case 2:
                timePassed = 60.0f;
                break;
            case 3:
                timePassed = 70.0f;
                break;
        }
        
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        StartCoroutine(StartTimer());
    }

    void Update(){
    }
}
