using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour {
    public GameObject[] objects;

    private bool isEnabled = false;
	// Use this for initialization
    public void EnableObjects(bool enable)
    {
        foreach (GameObject go in objects)
        {
            go.SetActive(enable);
        }
        isEnabled = enable;
    }
}
