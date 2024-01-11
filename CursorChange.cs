using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursorArrow;
    // public Texture2D cursorEnter;

    void Start()
    {
        // Cursor.visible  = false;
        Cursor.SetCursor(cursorArrow, Vector3.zero, CursorMode.ForceSoftware);
    }

    // void mouseEnter()
    // {
    //     // Cursor.visible  = false;
    //     Cursor.SetCursor(cursorEnter, Vector3.zero, CursorMode.ForceSoftware);
    // }

    // void mouseExit()
    // {
    //     // Cursor.visible  = false;
    //     Cursor.SetCursor(cursorArrow, Vector3.zero, CursorMode.ForceSoftware);
    // }
}
