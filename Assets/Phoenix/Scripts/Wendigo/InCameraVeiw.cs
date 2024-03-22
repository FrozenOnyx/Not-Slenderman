using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraVeiw : MonoBehaviour
{
    Camera cam;
    Plane[] cameraFrustrum;
    Collider col;

    public bool inCamera;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = col.bounds;
        cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(cam);
        if(GeometryUtility.TestPlanesAABB(cameraFrustrum, bounds))
        {
            inCamera = true;
        }
        else
        {
            inCamera = false;
        }
    }
}
