using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000006 RID: 6
public class CreditsBackButton : MonoBehaviour
{
	// Token: 0x06000010 RID: 16 RVA: 0x00002235 File Offset: 0x00000435
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.OpenScreen));
	}

	// Token: 0x06000011 RID: 17 RVA: 0x0000225F File Offset: 0x0000045F
	private void OpenScreen()
	{
		this.screen.SetActive(false);
	}

	// Token: 0x0400000B RID: 11
	private Button button;

	// Token: 0x0400000C RID: 12
	public GameObject screen;

	// Token: 0x0400000D RID: 13
	public AudioSource audioDevice;

	// Token: 0x0400000E RID: 14
	public AudioClip music;
}
