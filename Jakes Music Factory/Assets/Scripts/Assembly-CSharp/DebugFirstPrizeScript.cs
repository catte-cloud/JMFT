using System;
using UnityEngine;

// Token: 0x02000033 RID: 51
public class DebugFirstPrizeScript : MonoBehaviour
{
	// Token: 0x060000D5 RID: 213 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x000049FC File Offset: 0x00002BFC
	private void Update()
	{
		base.transform.position = this.first.position + new Vector3((float)Mathf.RoundToInt(this.first.forward.x), 0f, (float)Mathf.RoundToInt(this.first.forward.z)) * 3f;
	}

	// Token: 0x040000FB RID: 251
	public Transform player;

	// Token: 0x040000FC RID: 252
	public Transform first;
}
