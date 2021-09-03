using System;
using UnityEngine;

// Token: 0x02000013 RID: 19
public class LockCursorEffect : MonoBehaviour
{
	// Token: 0x06000045 RID: 69 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00002779 File Offset: 0x00000979
	private void Update()
	{
		this.cursor.LockCursor();
	}

	// Token: 0x0400002E RID: 46
	public CursorControllerScript cursor;
}
