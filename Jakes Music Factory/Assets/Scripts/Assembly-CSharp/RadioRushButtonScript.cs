using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x0200004F RID: 79
public class RadioRushButtonScript : MonoBehaviour
{
	// Token: 0x0600016D RID: 365 RVA: 0x0000940C File Offset: 0x0000760C
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.Load));
	}

	// Token: 0x0600016E RID: 366 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x0600016F RID: 367 RVA: 0x00002737 File Offset: 0x00000937
	private void Load()
	{
		SceneManager.LoadScene("GlitchyRunFactoryMap");
	}

	// Token: 0x04000267 RID: 615
	private Button button;
}
