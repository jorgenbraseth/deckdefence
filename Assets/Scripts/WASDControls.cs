using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControls : MonoBehaviour
{
    public float panSpeed = 5f;
    public float zoomSpeed = 35f;

    public float rotationSpeed = 5f;
    // Update is called once per frame
    void Update()
    {

        var forward = transform.forward;
        forward.y = 0;
        var right = transform.right;
        right.y = 0;
        if (Input.GetKey("w"))
        {
            transform.Translate(forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(-forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(-right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(right * panSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }

        var scrollDelta = Input.mouseScrollDelta.y;
        transform.Translate(Vector3.up * -scrollDelta * zoomSpeed * Time.deltaTime, Space.World);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -10, 10);
        pos.z = Mathf.Clamp(pos.z, -11, 11);
        pos.y = Mathf.Clamp(pos.y, 2, 15);
        transform.position = pos;

        var relativeY = (pos.y - 13)/13;
        var angle = 55 + (30 * relativeY);
        Vector3 rot = transform.rotation.eulerAngles;
        rot.x = angle;
        transform.rotation = Quaternion.Euler(rot);

    }
}
