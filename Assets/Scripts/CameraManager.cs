using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{

	public CinemachineVirtualCamera[] cameras;
	public CinemachineVirtualCamera leftView;
	public CinemachineVirtualCamera rightView;

	public CinemachineVirtualCamera startCamera;
	private CinemachineVirtualCamera curntCamera;
	// Update is called once per frame

	private void Start()
	{
		curntCamera = startCamera;

		for (int i = 0; i < cameras.Length; i++)
		{
			if (cameras[i] == curntCamera)
			{
				cameras[i].Priority = 20;
			}
			else
			{
				cameras[i].Priority = 10;
			}
		}
	}

	
	public void SwitchCamera(CinemachineVirtualCamera newCam)
	{
		curntCamera = newCam;

		curntCamera.Priority = 20;

		for (int i = 0; i < cameras.Length; i++)
		{
			if (cameras[i] != curntCamera)
			{
				cameras[i].Priority = 10;
			}
		}
	}
}
