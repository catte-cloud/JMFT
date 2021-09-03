using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200000F RID: 15
public class LoadSceneScript : MonoBehaviour
{
	// Token: 0x06000035 RID: 53 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x06000036 RID: 54 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00002737 File Offset: 0x00000937
	private void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene("GlitchyRunFactoryMap");
	}

	// Token: 0x0400002A RID: 42
	public Scene Scene;
}
