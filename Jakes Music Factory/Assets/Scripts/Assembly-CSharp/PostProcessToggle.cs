using System;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class PostProcessToggle : MonoBehaviour
{
	// Token: 0x0600006C RID: 108 RVA: 0x00002EF5 File Offset: 0x000010F5
	private void Start()
	{
		base.GetComponent<Camera>();
	}

	// Token: 0x0600006D RID: 109 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x04000060 RID: 96
	public Camera playercamera;
}
