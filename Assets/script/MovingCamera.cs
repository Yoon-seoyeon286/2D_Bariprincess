using UnityEngine;

public class MovingCamera : MonoBehaviour
{

    public float camerSpeed = 75.0f;
    public Transform target;

    void Start()
    {

    }


    void Update()
    {
        FollowPlayer();

    }

    void FollowPlayer()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
