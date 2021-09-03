using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000020 RID: 32
public class scenebutton : MonoBehaviour
{
	// Token: 0x0600007A RID: 122 RVA: 0x0000345B File Offset: 0x0000165B
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.Load));
	}

	// Token: 0x0600007B RID: 123 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00003485 File Offset: 0x00001685
	private void Load()
	{
		SceneManager.LoadScene("MazeCraze");
	}

	// Token: 0x04000090 RID: 144
	private Button button;
}
