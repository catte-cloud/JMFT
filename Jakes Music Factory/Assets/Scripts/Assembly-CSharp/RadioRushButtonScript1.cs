using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000050 RID: 80
public class RadioRushButtonScript1 : MonoBehaviour
{
	// Token: 0x06000171 RID: 369 RVA: 0x00009436 File Offset: 0x00007636
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.Load));
	}

	// Token: 0x06000172 RID: 370 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00009460 File Offset: 0x00007660
	private void Load()
	{
		SceneManager.LoadScene("GlitchyRunFactoryMap 1");
	}

	// Token: 0x04000268 RID: 616
	private Button button;
}
