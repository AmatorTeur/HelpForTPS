using UnityEngine;

public class Example : MonoBehaviour
{
    public float Speed = 5;
    public float MinX = 0;
    public float MaxX = 3;

    float _direction = 1;

    private void Update()
    {
        float newPosition = transform.position.x + Speed * _direction * Time.deltaTime;
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        if (transform.position.x > MaxX)
        {
            _direction = -1;
        }
        else if (transform.position.x < MinX)
        {
            _direction = 1;
        }
    }
}

