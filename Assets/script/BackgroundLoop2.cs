using UnityEngine;

public class BackgroundLoop2 : MonoBehaviour
{
     float width;

    void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;

    }

    void Update()
    {

        if (transform.position.x <= -width)
        {
            Reposition();
        }

    }

    void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
        
    }
}
