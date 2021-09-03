using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200003A RID: 58
public class ExitTriggerScript : MonoBehaviour
{
	// Token: 0x060000EF RID: 239 RVA: 0x00004F00 File Offset: 0x00003100
	private void OnTriggerEnter(Collider other)
	{
		if (this.gc.notebooks >= 7 & other.tag == "Player")
		{
			if (this.gc.failedNotebooks >= 7)
			{
				SceneManager.LoadScene("Cutscene");
				return;
			}
			SceneManager.LoadScene("Results");
		}
	}

	// Token: 0x0400011B RID: 283
	public GameControllerScript gc;
}
