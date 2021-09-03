using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200002A RID: 42
public class BsodaEffectScript : MonoBehaviour
{
	// Token: 0x060000AA RID: 170 RVA: 0x00003D7C File Offset: 0x00001F7C
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
	}

	// Token: 0x060000AB RID: 171 RVA: 0x00003D8C File Offset: 0x00001F8C
	private void Update()
	{
		if (this.inBsoda)
		{
			this.agent.velocity = this.otherVelocity;
		}
		if (this.failSave > 0f)
		{
			this.failSave -= Time.deltaTime;
			return;
		}
		this.inBsoda = false;
	}

	// Token: 0x060000AC RID: 172 RVA: 0x0000205E File Offset: 0x0000025E
	private void FixedUpdate()
	{
	}

	// Token: 0x060000AD RID: 173 RVA: 0x00003DDC File Offset: 0x00001FDC
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "BSODA")
		{
			this.inBsoda = true;
			this.otherVelocity = other.GetComponent<Rigidbody>().velocity;
			this.failSave = 1f;
			return;
		}
		if (other.transform.name == "Gotta Sweep")
		{
			this.inBsoda = true;
			this.otherVelocity = base.transform.forward * this.agent.speed * 0.1f + other.GetComponent<NavMeshAgent>().velocity;
			this.failSave = 1f;
		}
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00003E83 File Offset: 0x00002083
	private void OnTriggerExit()
	{
		this.inBsoda = false;
	}

	// Token: 0x040000C7 RID: 199
	private NavMeshAgent agent;

	// Token: 0x040000C8 RID: 200
	private Vector3 otherVelocity;

	// Token: 0x040000C9 RID: 201
	private bool inBsoda;

	// Token: 0x040000CA RID: 202
	private float failSave;
}
