using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000012 RID: 18
public class LoadSceneScript3 : MonoBehaviour
{
	// Token: 0x06000041 RID: 65 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x06000042 RID: 66 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x06000043 RID: 67 RVA: 0x0000275E File Offset: 0x0000095E
	private void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene("Factory");
		PlayerPrefs.SetString("CurrentMode", "double");
	}

	// Token: 0x0400002D RID: 45
	public StartButton startbutt;
}
