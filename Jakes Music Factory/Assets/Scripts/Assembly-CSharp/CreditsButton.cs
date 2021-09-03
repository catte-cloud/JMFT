using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000007 RID: 7
public class CreditsButton : MonoBehaviour
{
	// Token: 0x06000013 RID: 19 RVA: 0x0000226D File Offset: 0x0000046D
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.OpenScreen));
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002297 File Offset: 0x00000497
	private void OpenScreen()
	{
		this.screen.SetActive(true);
		this.screen2.SetActive(false);
	}

	// Token: 0x0400000F RID: 15
	private Button button;

	// Token: 0x04000010 RID: 16
	public GameObject screen;

	// Token: 0x04000011 RID: 17
	public GameObject screen2;
}
