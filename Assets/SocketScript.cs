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
    void Start()
    {
        if (!electrodeSocketManager.debugSockets(this))
        {
            visualizer.SetActive(false);
        }
        electrodeSocketManager.initializeSocket(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
