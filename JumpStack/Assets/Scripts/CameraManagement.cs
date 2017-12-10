using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour {
    public float moveTime = 1f;
    public float pullTime = 3f;
    private float CharacterYPos;
    private float CameraYPos;
    private float offset;
    Coroutine coroMove;

	void Start () {
        CharacterYPos = GameManager.instance.GetCharacter().transform.position.y;
        CameraYPos = transform.position.y;
        offset = CharacterYPos - CameraYPos;   
	}
	public void BeginPullBack()
    {
        if (coroMove != null)
        {
            StopCoroutine(coroMove);
        }
        StartCoroutine(PullBack());
    }
    public void BeginMove()
    {
        if (coroMove != null)
        {
            StopCoroutine(coroMove);
        }
        coroMove = StartCoroutine(MoveUp());
    }

    private IEnumerator MoveUp()
    {
        float elapsedTime = 0;
        CameraYPos = transform.position.y;
        CharacterYPos = GameManager.instance.GetCharacter().transform.position.y;
        while (elapsedTime < moveTime)
        {
            elapsedTime += Time.deltaTime;
            Vector3 newPos = transform.position;
            newPos.y = Mathf.Lerp(CameraYPos, CharacterYPos - offset, elapsedTime / moveTime);
            transform.position = newPos;
            yield return new WaitForEndOfFrame();
        }
        coroMove = null;
    }

    private IEnumerator PullBack()
    {
        float elapsedTime = 0;
        float CameraZPos = transform.position.z;
        while (elapsedTime < pullTime)
        {
            elapsedTime += Time.deltaTime;
            Vector3 newPos = transform.position;
            newPos.z = Mathf.Lerp(CameraZPos, Mathf.Min(CameraZPos - GameManager.instance.GetStackCount(), 25f), elapsedTime / pullTime);
            transform.position = newPos;
            yield return new WaitForEndOfFrame();
        }
    }

}
