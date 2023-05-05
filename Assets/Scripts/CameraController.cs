using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;

    private SpriteRenderer _backgroundData;

    // Start is called before the first frame update
    void Start()
    {
        _backgroundData = GameObject.Find("Background").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player with the camera
        transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y,
            transform.position.z);

        KeepCameraInsideGameField();
    }

    // Prevent the camera from moving off the background plane
    private void KeepCameraInsideGameField()
    {
        // Get properties of the background image
        float fieldWidth = _backgroundData.bounds.size.x;
        float fieldHeight = _backgroundData.bounds.size.y;
        Vector3 origin = _backgroundData.bounds.center;

        // Calculate border positions of the background image
        float start = origin.x - fieldWidth / 2f;
        float end = origin.x + fieldWidth / 2f;
        float top = origin.y + fieldHeight / 2f;
        float bottom = origin.y - fieldHeight / 2f;

        // Get properties of the camera
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;

        // Set camera position
        if (transform.position.x - cameraHalfWidth < start)
        {
            transform.position = new Vector3(start + cameraHalfWidth, transform.position.y, transform.position.z);
        }

        if (transform.position.x + cameraHalfWidth > end)
        {
            transform.position = new Vector3(end - cameraHalfWidth, transform.position.y, transform.position.z);
        }

        if (transform.position.y - cameraHalfHeight < bottom)
        {
            transform.position = new Vector3(transform.position.x, bottom + cameraHalfHeight, transform.position.z);
        }

        if (transform.position.y + cameraHalfHeight > top)
        {
            transform.position = new Vector3(transform.position.x, top - cameraHalfHeight, transform.position.z);
        }
    }
}