using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHitReporter : MonoBehaviour {
    public CameraManagement moveCam;
    public bool isLeft;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameManager.instance.GetCharacter())
        {
            GameManager.instance.SetGameOver();
            Rigidbody rb = GameManager.instance.GetCharacter().GetComponent<Rigidbody>();
            Vector3 bumpDirection = transform.right;
            if (isLeft) bumpDirection = -transform.right;

            rb.AddForce(bumpDirection * 5, ForceMode.Impulse);
            moveCam.BeginPullBack();
        }
    }
}
