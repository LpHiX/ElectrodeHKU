using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    public Transform camTransform;
    private Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = originalRotation * camTransform.rotation;
    }
}
