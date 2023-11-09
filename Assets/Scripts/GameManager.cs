using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    void Start() {
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = "Scorer: " + score;
    }
    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    void Update(){
        
    }
}
