using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultButton : MonoBehaviour {
    private Button button;
    private GameManager gameManager;
    public int difficulty;
    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDificulty);
    }

    void SetDificulty() {
        gameManager.StartGame(difficulty);
    }
    void Update()
    {
        
    }
}
