using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueFound_Audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Clue");
        }
    }

}
