using UnityEngine;
using System.Collections;
using System.Reflection;
using Leap.Unity;
using System.Linq;
using System.Collections.Generic;

public class HapticEffectSimple : MonoBehaviour {

    public Hand hand;
    public Finger finger;
    public float zOffset = 0.017f;
    static byte intensity = 31;


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "LeapModel")
        {
            PipeClient.Vibrate(hand.ToString(), finger.ToString(), intensity);
        }
    }

  

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag != "LeapModel")
        {
            PipeClient.Vibrate(hand.ToString(), finger.ToString(), 0);
        }
    }


    public enum Hand
    {
        right,
        left
    }

    public enum Finger
    {
        thumb,
        index,
        middle,
        ring,
        pinky
    }


}
