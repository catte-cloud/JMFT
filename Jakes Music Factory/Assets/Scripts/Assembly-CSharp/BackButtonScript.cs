using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000026 RID: 38
public class BackButtonScript : MonoBehaviour
{
	// Token: 0x06000096 RID: 150 RVA: 0x000038DC File Offset: 0x00001ADC
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.CloseScreen));
	}

	// Token: 0x06000097 RID: 151 RVA: 0x00003906 File Offset: 0x00001B06
	private void CloseScreen()
	{
		this.screen.SetActive(false);
	}

	// Token: 0x040000A7 RID: 167
	private Button button;

	// Token: 0x040000A8 RID: 168
	public GameObject screen;
}
