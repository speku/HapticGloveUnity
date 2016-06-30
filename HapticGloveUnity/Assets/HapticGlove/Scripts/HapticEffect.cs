using UnityEngine;
using System.Collections;
using System.Reflection;
using Leap.Unity;
using System.Linq;
using System.Collections.Generic;

 public class HapticEffect : MonoBehaviour {
    [HideInInspector]
    public Hand hand;
    [HideInInspector]
    public string finger;
    public float zOffset = 0.017f;
    static string boneName = "bone3";
    static bool initialized = false;
    static Dictionary<string, Hand> handNames = new Dictionary<string, Hand>() {
        { "RigidRoundHand_R", Hand.right },
        { "RigidRoundHand_L", Hand.left },
    };
    static byte intensity = 31;

    void OnAwake()
    {
        if (!initialized)
        {
            initialized = true;
            FindObjectsOfType<RigidFinger>().SelectMany(x => x.transform.Cast<Transform>().Where(y => y.gameObject.name == boneName)).Select(z => z.gameObject).ToList().ForEach(o =>
            {
                o.AddComponent<HapticEffect>().Initialize(handNames[o.transform.parent.parent.gameObject.name], o.transform.parent.name);
            });
        } else
        {
            transform.localPosition = transform.parent.localPosition + new Vector3(0, 0, zOffset);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "LeapModel")
        {
            Debug.Log("should vibrate");
            //PipeClient.Vibrate(hand.ToString(), finger.ToString(), intensity);
        }
    }

    public void Initialize(Hand hand, string finger)
    {
        this.hand = hand;
        this.finger = finger;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag != "LeapModel")
        {
            //PipeClient.Vibrate(hand.ToString(), finger.ToString(), 0);
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
