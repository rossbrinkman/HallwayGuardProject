using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public static bool playerInRoom;
    private Vector3 destination;
    private AudioSource audioSource;

    bool playerInRadius;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerInRadius = false;
        destination = GetRoamLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (destination != null)
        {
            agent.SetDestination(destination);
        }
        if (agent.remainingDistance == 0)
        {
            destination = GetRoamLocation();
        }
        if (PauseMenuScript.GamePaused || Keypad.gameOver)
        {
            audioSource.mute = true;
        }
        else { audioSource.mute = false; }
    }

    Vector3 GetRoamLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        int t = Random.Range(0, navMeshData.indices.Length);

        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        return point;
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !playerInRadius && !playerInRoom)
        {
            playerInRadius = true;
            destination = other.gameObject.transform.position;
            FindObjectOfType<AudioManager>().Play("Detected");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !playerInRoom)
        {
            destination = other.gameObject.transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && playerInRadius)
        {
            playerInRadius = false;
            destination = new Vector3(0,0,0);
            destination = GetRoamLocation();
        }
    }
}
