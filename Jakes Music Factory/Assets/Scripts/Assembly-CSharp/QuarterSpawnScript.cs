using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
public class QuarterSpawnScript : MonoBehaviour
{
	// Token: 0x0600016A RID: 362 RVA: 0x000093D5 File Offset: 0x000075D5
	private void Start()
	{
		this.wanderer.QuarterExclusive();
		base.transform.position = this.location.position + Vector3.up * 4f;
	}

	// Token: 0x0600016B RID: 363 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x04000265 RID: 613
	public AILocationSelectorScript wanderer;

	// Token: 0x04000266 RID: 614
	public Transform location;
}
