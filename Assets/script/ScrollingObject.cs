using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 0.1f;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
    }
}
