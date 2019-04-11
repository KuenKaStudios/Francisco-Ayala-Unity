using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform Target;
    public float cameraDistance = 30.0f;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
    }
}
