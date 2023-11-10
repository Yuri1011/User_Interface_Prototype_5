using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour {
    public Texture2D customCursor; // Пользовательский курсор

    void Start() {
        // Заменяем стандартный курсор на пользовательский
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        
    }
}
