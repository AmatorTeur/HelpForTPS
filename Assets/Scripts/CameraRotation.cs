using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;
    public float minAxis = 1;
    public float maxAxis = 10;
    public float _rotationSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * _rotationSpeed * Input.GetAxis("Mouse X"), 0);
        var n = CameraAxisTransform.localEulerAngles.x + Time.deltaTime * _rotationSpeed * -Input.GetAxis("Mouse Y");
        var newAxis = Mathf.Clamp(n, minAxis, maxAxis);
        CameraAxisTransform.localEulerAngles = new Vector3(newAxis, 0, 0);
    }
}
