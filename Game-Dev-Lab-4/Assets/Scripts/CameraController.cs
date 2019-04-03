using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// References:
//  - https://answers.unity.com/questions/1006959/stop-camera-when-wall-hit-2d-game.html
//  - Dr. Karaman's `2DBackgroundScrolling` example

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    public GameObject topEdge;
    public GameObject bottomEdge;
    public GameObject leftEdge;
    public GameObject rightEdge;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        xMin = leftEdge.transform.position.x + 2f;
        xMax = rightEdge.transform.position.x - 2f;
        yMin = bottomEdge.transform.position.y + 2f;
        yMax = topEdge.transform.position.y - 2f;
    }

    // Use LateUpdate for camera movement
    void LateUpdate()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;

        // Figure out if camera needs to move on x-axis
        if (player.transform.position.x > xMin && player.transform.position.x < xMax)
        {
            newX = player.transform.position.x + offset.x;
        }

        // Figure out if camera needs to move on y-axis
        if (player.transform.position.y > yMin && player.transform.position.y < yMax)
        {
            newY = player.transform.position.y + offset.y;
        }

        // Set new camera position
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
