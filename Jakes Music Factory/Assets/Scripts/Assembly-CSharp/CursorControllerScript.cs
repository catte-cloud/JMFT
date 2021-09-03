using System;
using UnityEngine;

// Token: 0x02000031 RID: 49
public class CursorControllerScript : MonoBehaviour
{
	// Token: 0x060000CB RID: 203 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x060000CC RID: 204 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x060000CD RID: 205 RVA: 0x000049DF File Offset: 0x00002BDF
	public void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Token: 0x060000CE RID: 206 RVA: 0x000049ED File Offset: 0x00002BED
	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
