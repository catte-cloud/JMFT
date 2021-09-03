using System;
using UnityEngine;

// Token: 0x02000045 RID: 69
public class NearExitTriggerScript : MonoBehaviour
{
	// Token: 0x06000139 RID: 313 RVA: 0x000078FC File Offset: 0x00005AFC
	private void OnTriggerEnter(Collider other)
	{
		if (this.gc.exitsReached < 3 & this.gc.finaleMode & other.tag == "Player")
		{
			this.gc.ExitReached();
			this.es.Lower();
			this.gc.baldiScrpt.Hear(base.transform.position, 5f);
		}
	}

	// Token: 0x040001E8 RID: 488
	public GameControllerScript gc;

	// Token: 0x040001E9 RID: 489
	public EntranceScript es;
}
