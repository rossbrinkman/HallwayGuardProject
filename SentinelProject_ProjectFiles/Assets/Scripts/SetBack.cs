using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBack : MonoBehaviour
{
    public GameObject player;

     IEnumerator Reset()
    {
        FindObjectOfType<AudioManager>().Play("Oof");
        //yield return new WaitForSeconds(0f);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = new Vector3(8.81f, 3.12790f, -11.12f);
        player.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(.2f);
        player.GetComponent<CharacterController>().enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            StartCoroutine(Reset());
    }
}
