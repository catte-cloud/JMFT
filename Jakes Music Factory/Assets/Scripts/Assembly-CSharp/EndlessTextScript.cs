using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000037 RID: 55
public class EndlessTextScript : MonoBehaviour
{
	// Token: 0x060000E6 RID: 230 RVA: 0x00004E0C File Offset: 0x0000300C
	private void Start()
	{
		this.text.text = "Robber Mode:\nSTEAL as many Instruments as you can!\nStolen Instruments:\n " + PlayerPrefs.GetInt("HighBooks") + " Notebooks";
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x04000115 RID: 277
	public Text text;
}
