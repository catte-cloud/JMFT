using System;
using UnityEngine;

// Token: 0x02000038 RID: 56
public class EntranceScript : MonoBehaviour
{
	// Token: 0x060000E9 RID: 233 RVA: 0x00004E38 File Offset: 0x00003038
	public void Lower()
	{
		base.transform.position = base.transform.position - new Vector3(0f, 10f, 0f);
		if (this.gc.finaleMode)
		{
			this.wall.material = this.map;
		}
	}

	// Token: 0x060000EA RID: 234 RVA: 0x00004E92 File Offset: 0x00003092
	public void Raise()
	{
		base.transform.position = base.transform.position + new Vector3(0f, 10f, 0f);
	}

	// Token: 0x04000116 RID: 278
	public GameControllerScript gc;

	// Token: 0x04000117 RID: 279
	public Material map;

	// Token: 0x04000118 RID: 280
	public MeshRenderer wall;
}
