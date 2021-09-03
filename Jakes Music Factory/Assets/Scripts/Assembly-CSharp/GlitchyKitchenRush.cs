using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x0200000A RID: 10
public class GlitchyKitchenRush : MonoBehaviour
{
	// Token: 0x0600001D RID: 29 RVA: 0x00002306 File Offset: 0x00000506
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.Load));
	}

	// Token: 0x0600001E RID: 30 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002330 File Offset: 0x00000530
	private void Load()
	{
		SceneManager.LoadScene("GlitchyRunKitchenMap");
	}

	// Token: 0x04000015 RID: 21
	private Button button;
}
