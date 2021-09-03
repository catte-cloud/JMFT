using System;
using UnityEngine;

// Token: 0x02000017 RID: 23
public class MouseMainMenuControl : MonoBehaviour
{
	// Token: 0x06000051 RID: 81 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x06000052 RID: 82 RVA: 0x0000296E File Offset: 0x00000B6E
	private void Update()
	{
		this.cursor.UnlockCursor();
	}

	// Token: 0x04000039 RID: 57
	public CursorControllerScript cursor;
}
