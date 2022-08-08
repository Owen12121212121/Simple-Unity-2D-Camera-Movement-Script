using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 motion;
    private float panSpeed = 20f;
    private float zoomSpeed = 500f;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        motion = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), -Input.GetAxisRaw("Mouse ScrollWheel"));
        mainCamera.transform.position += motion * panSpeed * Time.deltaTime / 10 * mainCamera.orthographicSize;
        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize + motion.z * zoomSpeed * Time.deltaTime, 0.1f, 20);
    }
}
