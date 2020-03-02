using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseController : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 stickLook;
    Vector2 smoothV;
    Vector2 cSmoothV;
    public float sensitivity;
    public float smoothing;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        MouseCont();
        StickCont();
    }

    void MouseCont()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        Debug.Log("mouse" + md);
        /*if (mouseLook.y <= 90)
        {
            //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.up);
            player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
        }*/
    }

    void StickCont()
    {
        var md = new Vector2(Input.GetAxisRaw("R_JoyStickHor"), Input.GetAxisRaw("R_JoyStickVert"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
    }
}
