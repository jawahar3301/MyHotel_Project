using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpGradeSystem : MonoBehaviour
{
  [SerializeField] public int upGradeAmount;
  [SerializeField] private TextMeshProUGUI ugAmount;
  [SerializeField] public GameObject Level1;
  [SerializeField] private GameObject Level2;
	public GameObject indicator;
	public Detection detection;
	public bool level1Upgraded=false;
	private bool level2Upgraded = false;

	void Start()
    {
		indicator.SetActive(true);
		upGradeAmount = 100;
		ugAmount.text = upGradeAmount.ToString();
	}
	public int UpGrade(int money)
	{
		if ( money >= upGradeAmount && upGradeAmount!=0)
		{
			money --;
			upGradeAmount--;
			ugAmount.text = upGradeAmount.ToString();

			Debug.Log("Upgrading");
		   indicator.SetActive(false);
			return money;
		}

		if (upGradeAmount == 0)
		{
			
			if(level1Upgraded != true)
			{
				level1Upgraded= true;
				Debug.Log("upgraded");
				checklevelcompletion();
				detection.audioSource.clip = detection.audioClip[2];
				detection.audioSource.Play();
				
				return money;
			}
			return money;
		}
		return money;
	}

	void checklevelcompletion()
	{
		if (level1Upgraded == true&& level2Upgraded!=true)
		{
			Level1.SetActive(false);
			Level2.SetActive(true);
			upGradeAmount = 200;
			ugAmount.text = upGradeAmount.ToString();
			
			
		}
	}


}


