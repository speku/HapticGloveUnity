using UnityEngine;
using System.Collections;

public class HapticEffectManager : MonoBehaviour {

	void OnApplicationQuit()
    {
        PipeClient.Close();
    }
}
