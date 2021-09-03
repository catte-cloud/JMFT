using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000010 RID: 16
public class LoadSceneScript1 : MonoBehaviour
{
	// Token: 0x06000039 RID: 57 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x0600003A RID: 58 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00002366 File Offset: 0x00000566
	private void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene("GlitchyRunSewerMap");
	}

	// Token: 0x0400002B RID: 43
	public Scene Scene;
}
