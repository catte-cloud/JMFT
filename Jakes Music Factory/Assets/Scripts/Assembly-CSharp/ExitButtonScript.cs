using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000039 RID: 57
public class ExitButtonScript : MonoBehaviour
{
	// Token: 0x060000EC RID: 236 RVA: 0x00004EC3 File Offset: 0x000030C3
	private void Start()
	{
		this.cursorController.UnlockCursor();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ExitGame));
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00004EF8 File Offset: 0x000030F8
	private void ExitGame()
	{
		Application.Quit();
	}

	// Token: 0x04000119 RID: 281
	public CursorControllerScript cursorController;

	// Token: 0x0400011A RID: 282
	private Button button;
}
