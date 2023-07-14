using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // Start is called before the first frame update

    public PuzzleTile[] tiles = new PuzzleTile[4];
    public Vector3 startingPosition;
    public Vector3 hiddenPosition;

    public float wallSpeed = 1.0f;

    void Start()
    {
        startingPosition = transform.position;

        hiddenPosition = transform.position - new Vector3(0, 10.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        bool allActive = true;
        Vector3 targetPosition;

        foreach (PuzzleTile tile in tiles)
        {
            allActive &= tile.active;
        }

        if (allActive)
        {
            targetPosition = hiddenPosition;
        }
        else
        {
            targetPosition = startingPosition;
        }

        float step = wallSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}