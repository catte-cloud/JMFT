using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class animationcontroller : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Start()
	{
		this.anim = base.GetComponent<Animator>();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002060 File Offset: 0x00000260
	public void OnTriggerEnter(Collider other)
	{
		this.anim.Play("DoorOpenAnim");
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002072 File Offset: 0x00000272
	public void OnTriggerExit(Collider other)
	{
		this.anim.Play("DoorCloseAnim");
	}

	// Token: 0x04000001 RID: 1
	public Animator anim;
}
