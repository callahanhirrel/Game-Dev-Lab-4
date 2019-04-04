using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingandParallax : MonoBehaviour
{
    public Camera cam;
    public float backgroundSize;
    public float parallaxSpeed;

    private Transform cameraTrans;
    private Transform[] layers;
    public float viewZone;
    private int leftIndex;
    private int rightIndex;
    private float camPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Scrolling
        cameraTrans = cam.transform;
        layers = new Transform[transform.childCount];

        for (int i=0; i<transform.childCount; i++) 
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;

        // Parallax
        camPosition = cameraTrans.position.x;
    }

    private void ScrollLeft()
    {
        layers[rightIndex].position = new Vector2((layers[leftIndex].position.x - backgroundSize), layers[leftIndex].position.y);

        leftIndex = rightIndex;
        rightIndex = rightIndex - 1;

        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        layers[leftIndex].position = new Vector2((layers[rightIndex].position.x + backgroundSize), layers[rightIndex].position.y);

        rightIndex = leftIndex;
        leftIndex = leftIndex + 1;

        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Scrolling
        if (cameraTrans.position.x < (layers[leftIndex].position.x + viewZone))
        {
            ScrollLeft();
        }
        if (cameraTrans.position.x > (layers[rightIndex].position.x - viewZone))
        {
            ScrollRight();
        }

        // Parallax
        float offset = cameraTrans.position.x - camPosition;
        transform.position += new Vector3(offset * parallaxSpeed, 0);
        camPosition = cameraTrans.position.x;
    }
}
