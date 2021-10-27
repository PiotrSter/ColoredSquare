using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public Transform playerPosition, cameraPosition;
    private float cameraOffset;
    void Awake()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        cameraPosition = this.GetComponent<Transform>();
    }

    void Update()
    {
        cameraPosition.position = new Vector3(cameraPosition.position.x, playerPosition.position.y + 2.5f, cameraPosition.position.z);
    }
}
