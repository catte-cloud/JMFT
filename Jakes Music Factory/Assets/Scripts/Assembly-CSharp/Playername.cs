using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200001B RID: 27
public class Playername : MonoBehaviour
{
	// Token: 0x06000061 RID: 97 RVA: 0x00002C5F File Offset: 0x00000E5F
	private void Start()
	{
		PlayerPrefs.GetString("PlayerName", this.theName);
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00002C72 File Offset: 0x00000E72
	private void Update()
	{
		this.Nametext.text = PlayerPrefs.GetString("PlayerName", this.theName);
	}

	// Token: 0x0400004D RID: 77
	public string theName;

	// Token: 0x0400004E RID: 78
	public Text Nametext;
}
