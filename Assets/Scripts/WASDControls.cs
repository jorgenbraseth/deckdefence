using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControls : MonoBehaviour
{
    public float panSpeed = 5f;

    public float zoomSpeed = 35f;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        var scrollDelta = Input.mouseScrollDelta.y;
        transform.Translate(Vector3.up * -scrollDelta * zoomSpeed * Time.deltaTime, Space.World);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -10, 10);
        pos.z = Mathf.Clamp(pos.z, -11, 6);
        pos.y = Mathf.Clamp(pos.y, 2, 15);
        transform.position = pos;

        var relativeY = (pos.y - 13)/13;
        var angle = 55 + (30 * relativeY);
        Vector3 rot = transform.rotation.eulerAngles;
        rot.x = angle;
        transform.rotation = Quaternion.Euler(rot);

    }
}
