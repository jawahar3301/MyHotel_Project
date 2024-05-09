using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawn : MonoBehaviour
{
    public GameObject money;
	
	void Start()
	{
		
	}
	public void Spawn()
    {
        Vector3 spawnPosition = this.gameObject.transform.position;
        Instantiate(money, spawnPosition, this.gameObject.transform.rotation);
		
		
    }
}
