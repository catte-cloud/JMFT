using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000009 RID: 9
public class gametirgger : MonoBehaviour
{
	// Token: 0x06000019 RID: 25 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x0600001A RID: 26 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000022EB File Offset: 0x000004EB
	public void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene("Factory");
		PlayerPrefs.SetString("CurrentMode", "story");
	}

	// Token: 0x04000014 RID: 20
	public StartButton start;
}
