using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //float yValue = Mathf.Lerp(3.5f, 4.5f, Time.deltaTime/1);

        //print(yValue);

        transform.position = new Vector3(transform.position.x , Mathf.SmoothStep(3.5f, 4.5f, Mathf.PingPong(Time.deltaTime, 1)), transform.position.z);
    }
}
