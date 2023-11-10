using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {
    public Button closeButton;
    void Start() {
        closeButton.onClick.AddListener(CloseGameFunction);
    }

    void CloseGameFunction() {
        // Закрыть приложение (работает в standalone приложениях)
        Application.Quit();
    }
    void Update()
    {
        
    }
}
