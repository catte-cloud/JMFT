using System;
using UnityEngine;

// Token: 0x0200005E RID: 94
public class ConveyorScript : MonoBehaviour
{
	// Token: 0x060001B4 RID: 436 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x0000A2BC File Offset: 0x000084BC
	private void Update()
	{
		if (this.inside & Time.deltaTime != 0)
		{
			this.Player.transform.position -= Vector3.left * 0.2f;
		}
		if (!this.inside & Time.deltaTime != 0)
		{
			this.Player.transform.position -= Vector3.left * 0f;
		}
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x0000A32D File Offset: 0x0000852D
	public void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Player")
		{
			this.inside = true;
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x0000A34D File Offset: 0x0000854D
	public void OnTriggerExit(Collider other)
	{
		if (other.transform.name == "Player")
		{
			this.inside = false;
		}
	}

	// Token: 0x040002C6 RID: 710
	public bool inside;

	// Token: 0x040002C7 RID: 711
	public GameObject Player;

	// Token: 0x040002C8 RID: 712
	public Collider conveyorcollider;
}
