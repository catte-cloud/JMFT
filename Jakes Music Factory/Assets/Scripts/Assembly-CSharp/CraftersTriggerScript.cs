using System;
using UnityEngine;

// Token: 0x02000030 RID: 48
public class CraftersTriggerScript : MonoBehaviour
{
	// Token: 0x060000C8 RID: 200 RVA: 0x00004989 File Offset: 0x00002B89
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.crafters.GiveLocation(this.goTarget.position, false);
		}
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x000049B4 File Offset: 0x00002BB4
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.crafters.GiveLocation(this.fleeTarget.position, true);
		}
	}

	// Token: 0x040000F8 RID: 248
	public Transform goTarget;

	// Token: 0x040000F9 RID: 249
	public Transform fleeTarget;

	// Token: 0x040000FA RID: 250
	public CraftersScript crafters;
}
