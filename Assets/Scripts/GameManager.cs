using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    void Start() {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        StartCoroutine(StartTimer());
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
            timePassed++;
            // Обновление текста на экране с отображением времени
            timeText.text = "Time: " + timePassed.ToString("F0") + "s";
            if (timePassed >= 60f && score != 57) {
                // Когда время закончится, активируйте текст окончания игры
                gameOverText.gameObject.SetActive(true);
                timerRunning = false; // Останавливаем таймер
            } else if (score == 57) {
                gameWinText.gameObject.SetActive(true);
                timerRunning = false; // Останавливаем таймер
            }
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    void Update(){
    }
}
