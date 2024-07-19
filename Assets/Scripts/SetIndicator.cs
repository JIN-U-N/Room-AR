using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SetIndicator : MonoBehaviour
{
    public ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits= new List<ARRaycastHit>();
    public GameObject Indicator;
    public Animator animator;

    void Start()
    {
        Indicator.SetActive(false);
    }

    void Update()
    {
        var ray= new Vector3(Screen.width/2,Screen.height/2);
        if(aRRaycastManager.Raycast(ray,hits,TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose=hits[0].pose;
            Indicator.transform.position=hitPose.position;
            Indicator.transform.rotation=hitPose.rotation;
            if (!Indicator.activeInHierarchy)
            {
                Indicator.SetActive(true);
            }
        }
    }
}
