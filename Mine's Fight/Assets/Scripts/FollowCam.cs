using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform playerTr;
    Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        camera.position = new Vector3 (playerTr.position.x-0.03f, camera.position.y, playerTr.position.z-11.0f);
    }
}
