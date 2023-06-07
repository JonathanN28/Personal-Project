using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuCameraMove : MonoBehaviour
{
    public GameObject MainCamera;

    public GameObject RotatingCube;

    public Vector3 offset;
    public int distanceFromCube = 30;
    public float rotationSpeed = 0.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 10, 0); // to make camera on same level
    }

    // Update is called once per frame
    void Update()
    {
        RotatingCube.transform.Rotate(Vector3.up * rotationSpeed);
        MainCamera.transform.position = RotatingCube.GetComponent<BoxCollider>().transform.TransformDirection(Vector3.left * distanceFromCube) + offset; // confusing, but changes camera to rotation of cube
        MainCamera.transform.rotation = Quaternion.FromToRotation(Vector3.left, RotatingCube.transform.forward); // i think it faces camera towards cube, but weird glitching effect if use (Vector.3 forward, RotatingCube.transform.right)
    }
}
