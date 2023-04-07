using UnityEngine;

public class UIMouseCursor : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
