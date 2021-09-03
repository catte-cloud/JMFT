using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x0200000B RID: 11
public class GlitchyRunSewer : MonoBehaviour
{
	// Token: 0x06000021 RID: 33 RVA: 0x0000233C File Offset: 0x0000053C
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.Load));
	}

	// Token: 0x06000022 RID: 34 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002366 File Offset: 0x00000566
	private void Load()
	{
		SceneManager.LoadScene("GlitchyRunSewerMap");
	}

	// Token: 0x04000016 RID: 22
	private Button button;
}
