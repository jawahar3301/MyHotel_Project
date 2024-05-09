using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Detection : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] private float dectectionRadius;

	public int Money;
	public TextMeshProUGUI countText;
	public GameObject upgradeCanvas;
	public GameObject unlockCanvas;

	public AudioSource audioSource;
	public AudioClip []audioClip;
	public CameraManager cameraManager;
	public GameObject indicator;

	private void Start()
	{
		indicator.SetActive(true);
	}
	void Update()
	{
		CameraView();
		DetectMoney();
		DetectRoomToClean();
		
			
		if (Money>=100)
		{
			upgradeCanvas.SetActive(true);
		}
		UpGradingRoom();

		if (Money>=400)
		{
			unlockCanvas.SetActive(true);
		}
		UnLockRoom();
		
		
	}

	private void DetectMoney()
	{
		countText.text = Money.ToString();

		Collider[] detectColliders = Physics.OverlapSphere(transform.position, dectectionRadius);
		foreach (Collider collider in detectColliders)
		{
			if (collider.TryGetComponent(out MoneyCollecting collecting))
			{
				collecting.Attract();

				audioSource.clip = audioClip[0];
				audioSource.Play();
			}
		}
	}
	private void DetectRoomToClean()
	{
		
		Collider[] detectColliders = Physics.OverlapSphere(transform.position, dectectionRadius);
		foreach (Collider collider in detectColliders)
		{
			if (collider.TryGetComponent(out Cleaning cleaner))
			{
				if (!cleaner.Cleaned())
				{
					cleaner.Clean();
					
					audioSource.clip = audioClip[1];
					audioSource.Play();
				}
				
			}
			
		}
	}

	private void UpGradingRoom()
	{
		
		Collider[] detectColliders = Physics.OverlapSphere(transform.position, dectectionRadius);
		foreach (Collider collider in detectColliders)
		{
			if (collider.TryGetComponent(out UpGradeSystem upgrade))
			{
				Money = upgrade.UpGrade(Money);
				if(upgrade.upGradeAmount!=0)
				{
					countText.text = Money.ToString();
				}
				
			}
		}
		
	}

	private void UnLockRoom()
	{

		Collider[] detectColliders = Physics.OverlapSphere(transform.position, dectectionRadius);
		foreach (Collider collider in detectColliders)
		{
			if (collider.TryGetComponent(out UnlockSystem unlock))
			{
				Money = unlock.Unlock(Money);
				if (unlock.unlockAmount != 0)
				{
					countText.text = Money.ToString();
					Destroy(unlock.indicator);
				}
				
			}
		}

	}

	private void CameraView()
	{
		Collider[] detectColliders = Physics.OverlapSphere(transform.position, dectectionRadius);
		foreach (Collider collider in detectColliders)
		{
			
			
			if (collider.gameObject.tag == "LeftView")
			{
					
				cameraManager.SwitchCamera(cameraManager.leftView);
				indicator.SetActive(false);
				Debug.Log("leftView...");
		    } 
			 if (collider.gameObject.tag == "RightView")
			 {
				  cameraManager.SwitchCamera(cameraManager.rightView);
				  Debug.Log("rightView...");
			}
			  if (collider.gameObject.tag == "Ground")
			  {
				cameraManager.SwitchCamera(cameraManager.startCamera);
				Debug.Log("mianView...");
			}


		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, dectectionRadius);
	}
}
