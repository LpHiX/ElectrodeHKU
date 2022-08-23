using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject visualizer;
    [SerializeField]
    private ElectrodeSocketManager electrodeSocketManager;
    [SerializeField]
    private SocketShowScript socketShowScript;
    void Start()
    {
        visualizer.SetActive(false);
        electrodeSocketManager.initializeSocket(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            visualizer.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            visualizer.SetActive(false);
        }
    }
}
