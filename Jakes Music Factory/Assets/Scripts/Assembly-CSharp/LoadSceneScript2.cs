using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000011 RID: 17
public class LoadSceneScript2 : MonoBehaviour
{
	// Token: 0x0600003D RID: 61 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x0600003E RID: 62 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00002743 File Offset: 0x00000943
	private void OnTriggerEnter(Collider other)
	{
		PlayerPrefs.SetString("CurrentMode", "pie");
		SceneManager.LoadScene("Factory");
	}

	// Token: 0x0400002C RID: 44
	public StartButton startbutt;
}
