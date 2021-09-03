using System;
using UnityEngine;

// Token: 0x0200003B RID: 59
public class FacultyTriggerScript : MonoBehaviour
{
	// Token: 0x060000F1 RID: 241 RVA: 0x00004F54 File Offset: 0x00003154
	private void Start()
	{
		this.hitBox = base.GetComponent<BoxCollider>();
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x00004F62 File Offset: 0x00003162
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			this.ps.ResetGuilt("faculty", 1f);
		}
	}

	// Token: 0x0400011C RID: 284
	public PlayerScript ps;

	// Token: 0x0400011D RID: 285
	private BoxCollider hitBox;
}
