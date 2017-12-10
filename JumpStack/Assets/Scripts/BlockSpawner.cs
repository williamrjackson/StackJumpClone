using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {
    public Block blockObject;
    public float spawnFrequency = 1f;

    private float elapsedTime = 0;
    private float yPos;
    private float yOffset;
	// Use this for initialization
	void Start () {
        blockObject.gameObject.SetActive(false);
        yPos = blockObject.transform.position.y;
        yOffset = blockObject.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > spawnFrequency && !GameManager.instance.GetGameOver())
        {
            SpawnBlock();
            elapsedTime = 0f;
        }
	}

    private void SpawnBlock()
    {
        GameObject blockSpawn = Instantiate(blockObject.gameObject);
        blockSpawn.transform.parent = transform;
        blockSpawn.transform.position = new Vector3(blockSpawn.transform.position.x, yPos, blockSpawn.transform.position.z);
        yPos += yOffset;
        blockSpawn.SetActive(true);
        Block block = blockSpawn.GetComponent<Block>();
        block.startLeft = RandomBool();
        block.rotateTime = Random.Range(1f, 1.5f);
    }

    private bool RandomBool()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
