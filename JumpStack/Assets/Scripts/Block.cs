using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    public float rotateTime = 1;
    public bool startLeft;
    public bool hasLanded;

    private float initialYRot;
	// Use this for initialization
	void Start () {
        if (startLeft)
        {
            transform.Rotate(0, 75, 0);
        }
        else
        {
            transform.Rotate(0, -75, 0);
        }
        initialYRot = transform.localRotation.eulerAngles.y;
        StartCoroutine(RotateIn());
    }
	
	// Update is called once per frame
	void Update () {

	}

    private IEnumerator RotateIn()
    {
        float elapsedTime = 0;
        while (elapsedTime < rotateTime && !hasLanded && !GameManager.instance.GetGameOver())
        {
            elapsedTime += Time.deltaTime;
            Vector3 eulerAngles = transform.localRotation.eulerAngles;
            eulerAngles.y = Mathf.LerpAngle(initialYRot, 0, elapsedTime / rotateTime);
            transform.localRotation = Quaternion.Euler(eulerAngles);
            yield return new WaitForEndOfFrame();
        }
    }
}
