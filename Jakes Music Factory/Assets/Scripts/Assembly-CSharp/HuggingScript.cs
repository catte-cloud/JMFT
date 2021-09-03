using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000041 RID: 65
public class HuggingScript : MonoBehaviour
{
	// Token: 0x06000120 RID: 288 RVA: 0x00007039 File Offset: 0x00005239
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
	}

	// Token: 0x06000121 RID: 289 RVA: 0x00007047 File Offset: 0x00005247
	private void Update()
	{
		if (this.failSave > 0f)
		{
			this.failSave -= Time.deltaTime;
			return;
		}
		this.inBsoda = false;
	}

	// Token: 0x06000122 RID: 290 RVA: 0x00007070 File Offset: 0x00005270
	private void FixedUpdate()
	{
		if (this.inBsoda)
		{
			this.rb.velocity = this.otherVelocity;
		}
	}

	// Token: 0x06000123 RID: 291 RVA: 0x0000708C File Offset: 0x0000528C
	private void OnTriggerStay(Collider other)
	{
		if (other.transform.name == "1st Prize")
		{
			this.inBsoda = true;
			this.otherVelocity = this.rb.velocity * 0.1f + other.GetComponent<NavMeshAgent>().velocity;
			this.failSave = 1f;
		}
	}

	// Token: 0x06000124 RID: 292 RVA: 0x000070ED File Offset: 0x000052ED
	private void OnTriggerExit()
	{
		this.inBsoda = false;
	}

	// Token: 0x040001B0 RID: 432
	private Rigidbody rb;

	// Token: 0x040001B1 RID: 433
	private Vector3 otherVelocity;

	// Token: 0x040001B2 RID: 434
	public bool inBsoda;

	// Token: 0x040001B3 RID: 435
	private float failSave;
}
