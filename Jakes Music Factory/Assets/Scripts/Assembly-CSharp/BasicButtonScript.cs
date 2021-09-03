using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000028 RID: 40
public class BasicButtonScript : MonoBehaviour
{
	// Token: 0x060000A4 RID: 164 RVA: 0x00003CD0 File Offset: 0x00001ED0
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.OpenScreen));
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00003CFA File Offset: 0x00001EFA
	private void OpenScreen()
	{
		this.screen.SetActive(true);
	}

	// Token: 0x040000C4 RID: 196
	private Button button;

	// Token: 0x040000C5 RID: 197
	public GameObject screen;
}
