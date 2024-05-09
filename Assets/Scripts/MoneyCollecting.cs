using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCollecting : MonoBehaviour
{
   
    private int Money = 50;
	private Transform target;
	public float speed;
	
	
	
	
	void Start()
	{
	
		//moneySound = gameObject.GetComponent<AudioSource>();
	}
	
	private void OnCollisionEnter(Collision other)
	{
		
		if(other.gameObject.tag=="Player")
		{

			Detection md;
			md = other.gameObject.GetComponent<Detection>();
			md.Money += Money;
			
			Debug.Log(md.Money);
			Destroy(this.gameObject);

		}
	}
	
	public void Attract()
	{
		//moneySound.clip = moneyclip;
		//moneySound.Play(); 
		if (target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>())
		{
			
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
			
		}
		
	}
}
