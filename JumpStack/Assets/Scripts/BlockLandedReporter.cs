using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLandedReporter : MonoBehaviour {
    public Block block;
    public CameraManagement moveCam;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Character")
        {
            block.hasLanded = true;
            GameManager.instance.GetCharacter().GetComponent<Jump>().SetGrounded();
            GameManager.instance.IncrementStack();
            moveCam.BeginMove();
        }
    }
}
