using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockSystem : MonoBehaviour
{

	[SerializeField] public int unlockAmount;
	[SerializeField] private TextMeshProUGUI ugAmount;
	[SerializeField] private GameObject unlockRoom;
	public GameObject indicator;

	private bool Unlocked = false;
	
	void Start()
	{
		indicator.SetActive(true);
		unlockAmount = 400;
		ugAmount.text = unlockAmount.ToString();
	}

	


	public int Unlock(int money)
	{
		if (money >= unlockAmount && unlockAmount != 0)
		{
			money--;
			unlockAmount--;
			ugAmount.text = unlockAmount.ToString();

			Debug.Log("unlocking");

			return money;
		}

		if (unlockAmount == 0)
		{

			if (Unlocked != true)
			{
				Unlocked= true;
				Debug.Log("uplocked");
				checklevelcompletion();
			
				return money;
			}
			return money;
		}
		return money;
	}

	void checklevelcompletion()
	{
		if (Unlocked == true )
		{
			unlockRoom.SetActive(true);

			Destroy(this.gameObject);
		}
	}

}
