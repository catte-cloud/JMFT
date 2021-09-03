using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000053 RID: 83
public class skipbutton : MonoBehaviour
{
	// Token: 0x0600017C RID: 380 RVA: 0x00009517 File Offset: 0x00007717
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.OpenScreen));
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00009541 File Offset: 0x00007741
	private void OpenScreen()
	{
		SceneManager.LoadScene("MainMenu");
	}

	// Token: 0x0400026D RID: 621
	private Button button;

	// Token: 0x0400026E RID: 622
	public GameObject screen;
}
