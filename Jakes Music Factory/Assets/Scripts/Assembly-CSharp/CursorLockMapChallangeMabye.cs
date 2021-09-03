using System;
using UnityEngine;

// Token: 0x02000032 RID: 50
public class CursorLockMapChallangeMabye : MonoBehaviour
{
	// Token: 0x060000D0 RID: 208 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x000049DF File Offset: 0x00002BDF
	public void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x000049ED File Offset: 0x00002BED
	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
