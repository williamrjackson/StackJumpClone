using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject character;
    private bool gameOver = false;
    private int stackCount = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGameOver()
    {
        print("Game Over");
        gameOver = true;
    }
    public bool GetGameOver()
    {
        return gameOver;
    }

    public GameObject GetCharacter()
    {
        return character;
    }

    public void IncrementStack()
    {
        stackCount++;
    }
    public int GetStackCount()
    {
        return stackCount;
    }
}
