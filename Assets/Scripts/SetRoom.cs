using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SetRoom : MonoBehaviour
{
    SetIndicator setIndicator;
    public GameObject Room;
    public Animator animator;
    public AudioSource audioSource;

    public void Start()
    {
        setIndicator=FindObjectOfType<SetIndicator>();
    }

    public void RoomSet()
    {

        if(!Room.activeInHierarchy)
        {
            Room.SetActive(true);
            if(Room.activeSelf)
            {
                audioSource.Play();
                Handheld.Vibrate();
            }
            Room.transform.position=setIndicator.Indicator.transform.position;
            Room.transform.rotation=setIndicator.Indicator.transform.rotation;
        }
        Destroy(setIndicator.Indicator);
        animator.SetBool("UIFoldBool",false);
    }
    
    public void HomeSet()
    {
        animator.SetBool("UIFoldBool",true);
        Handheld.Vibrate();
    }
    
}
