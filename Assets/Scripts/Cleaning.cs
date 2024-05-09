using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cleaning : MonoBehaviour
{
    [SerializeField] private Image timer;
    [SerializeField] private float timerSpeed;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject signBoard;

    private float resetClaen = 10f;
    public bool cleaned;
    public MoneySpawn moneySpawn;
    
    void Start()
    {
       // cleanedSound=GetComponent<AudioSource>();
        NotCleaned();
        
    }
	
	public void Clean()
    {
        timer.fillAmount += timerSpeed * Time.deltaTime;
        if (timer.fillAmount >= 1)
        {
            SetAsClean();
            //cleanedSound.clip = cleanSound;
            //cleanedSound.Play();
        }

    }
    public void NotCleaned()
	{
        timer.fillAmount = 0;
        cleaned = false;
        canvas.SetActive(true);
        signBoard.SetActive(true);
        
	}
    
    

    private void SetAsClean()
	{
        cleaned = true;
        canvas.SetActive(false);
        signBoard.SetActive(false);
        Invoke("NotCleaned", resetClaen);
        moneySpawn.Spawn();
        moneySpawn.Spawn(); moneySpawn.Spawn();
        Debug.Log("It's Clean");
	}
    

    public bool Cleaned()
    {
       
        return cleaned;
       
	}
}
