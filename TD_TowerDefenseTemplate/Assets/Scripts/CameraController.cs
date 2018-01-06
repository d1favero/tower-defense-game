using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 30f;
    public float panBorderThickness = 50f;
    public float xMin = 10f, xMax = 10f, yMin = 10f, yMax = 10f;

    public int orthographicSizeMin = 20;
    public int orthographicSizeMax = 30;

    [SerializeField]
    Camera gameCamera;

    public int interval = 2;

    int startOrthographicSize = 24;
    private bool canMove = true;
    Vector3 startPosition;


    void Start()
    {
        gameCamera = this.GetComponent<Camera>();
        startPosition = transform.position;
        ResetCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameOver)
        {
            this.enabled = false;
            return;
        }
            

        if (Input.GetKeyDown(KeyCode.P))
            canMove = !canMove;

        if (!canMove)
            return;


        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            // forward
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            // backwards
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            // left
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            // right
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            transform.position.y,
            Mathf.Clamp(transform.position.z, yMin, yMax)
            );

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            ApplyZoom();

        if (Input.GetMouseButtonDown(2))
        {
            ResetCamera();
        }

    }

    private void ResetCamera()
    {
        transform.position = startPosition;
        gameCamera.orthographicSize = startOrthographicSize;
    }


    void ApplyZoom()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            gameCamera.orthographicSize -= interval;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            gameCamera.orthographicSize += interval;
        }

        gameCamera.orthographicSize = Mathf.Clamp(gameCamera.orthographicSize, orthographicSizeMin, orthographicSizeMax);

    }
}
