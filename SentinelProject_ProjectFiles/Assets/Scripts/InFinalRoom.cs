using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFinalRoom : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AIScript.playerInRoom = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AIScript.playerInRoom = false;
        }
    }
}
