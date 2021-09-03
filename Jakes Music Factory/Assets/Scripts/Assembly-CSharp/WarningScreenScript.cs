using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000059 RID: 89
public class WarningScreenScript : MonoBehaviour
{
	// Token: 0x0600019B RID: 411 RVA: 0x00009D7D File Offset: 0x00007F7D
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}
