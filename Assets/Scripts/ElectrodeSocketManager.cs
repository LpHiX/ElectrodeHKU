using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class ElectrodeSocketManager : MonoBehaviour
{
    [SerializeField]
    private SocketScript[] correctSockets = new SocketScript[6];
    private List<SocketScript> allSockets = new List<SocketScript>();
    public int[] placedSockets = { 0, 0, 0, 0, 0, 0 };
    // Start is called before the first frame update

    public bool debugSockets(SocketScript socket)
    {
        return Array.IndexOf(correctSockets, socket) > -1 ? true : false;
    }
    public void initializeSocket(SocketScript socket)
    {
        allSockets.Add(socket);
        XRSocketInteractor socketInteractor = socket.GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(enterMethods);
        socketInteractor.selectExited.AddListener(exitMethods);
    }
    private void enterMethods(SelectEnterEventArgs arg0)
    {
        SocketScript socketScript = arg0.interactorObject.transform.gameObject.GetComponent<SocketScript>();
        int check = Array.IndexOf(correctSockets, socketScript);
        if(check > -1)
        {
            ElectrodeScript electrodeScript = arg0.interactableObject.transform.gameObject.GetComponent<ElectrodeScript>();
            if( electrodeScript.electrodeNumber - 1 == check)
            {
                placedSockets[check] = 1;
            }
        }
        
    }
    private void exitMethods(SelectExitEventArgs arg0)
    {
        SocketScript socketScript = arg0.interactorObject.transform.gameObject.GetComponent<SocketScript>();
        int check = Array.IndexOf(correctSockets, socketScript);
        if (check > -1)
        {
            placedSockets[check] = 0;
        }
    }
}
