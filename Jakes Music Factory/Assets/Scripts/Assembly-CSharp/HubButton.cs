using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000040 RID: 64
public class HubButton : MonoBehaviour
{
	// Token: 0x0600011D RID: 285 RVA: 0x00007003 File Offset: 0x00005203
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.OpenScreen));
	}

	// Token: 0x0600011E RID: 286 RVA: 0x0000702D File Offset: 0x0000522D
	private void OpenScreen()
	{
		SceneManager.LoadScene("Beta Hub");
	}

	// Token: 0x040001AE RID: 430
	private Button button;

	// Token: 0x040001AF RID: 431
	public GameObject screen;
}
