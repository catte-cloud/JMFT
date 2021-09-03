using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
public class PickupAnimationScript : MonoBehaviour
{
	// Token: 0x0600013E RID: 318 RVA: 0x00007B32 File Offset: 0x00005D32
	private void Start()
	{
		this.itemPosition = base.GetComponent<Transform>();
	}

	// Token: 0x0600013F RID: 319 RVA: 0x00007B40 File Offset: 0x00005D40
	private void Update()
	{
		this.itemPosition.localPosition = new Vector3(0f, Mathf.Sin((float)Time.frameCount * 0.017453292f) / 2f + 1f, 0f);
	}

	// Token: 0x040001F2 RID: 498
	private Transform itemPosition;
}
