using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000055 RID: 85
public class SweepScript : MonoBehaviour
{
	// Token: 0x06000182 RID: 386 RVA: 0x00009619 File Offset: 0x00007819
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.audioDevice = base.GetComponent<AudioSource>();
		this.origin = base.transform.position;
		this.waitTime = UnityEngine.Random.Range(120f, 180f);
	}

	// Token: 0x06000183 RID: 387 RVA: 0x0000965C File Offset: 0x0000785C
	private void Update()
	{
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.waitTime > 0f)
		{
			this.waitTime -= Time.deltaTime;
			return;
		}
		if (!this.active)
		{
			this.active = true;
			this.wanders = 0;
			this.Wander();
			this.audioDevice.PlayOneShot(this.aud_Intro);
		}
	}

	// Token: 0x06000184 RID: 388 RVA: 0x000096DC File Offset: 0x000078DC
	private void FixedUpdate()
	{
		if ((double)this.agent.velocity.magnitude <= 0.1 & this.coolDown <= 0f & this.wanders < 5 & this.active)
		{
			this.Wander();
			return;
		}
		if (this.wanders >= 5)
		{
			this.GoHome();
		}
	}

	// Token: 0x06000185 RID: 389 RVA: 0x00009745 File Offset: 0x00007945
	private void Wander()
	{
		this.wanderer.GetNewTargetHallway();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 1f;
		this.wanders++;
	}

	// Token: 0x06000186 RID: 390 RVA: 0x00009782 File Offset: 0x00007982
	private void GoHome()
	{
		this.agent.SetDestination(this.origin);
		this.waitTime = UnityEngine.Random.Range(120f, 180f);
		this.wanders = 0;
		this.active = false;
	}

	// Token: 0x06000187 RID: 391 RVA: 0x000097B9 File Offset: 0x000079B9
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "NPC" || other.tag == "Player")
		{
			this.audioDevice.PlayOneShot(this.aud_Sweep);
		}
	}

	// Token: 0x04000270 RID: 624
	public Transform wanderTarget;

	// Token: 0x04000271 RID: 625
	public AILocationSelectorScript wanderer;

	// Token: 0x04000272 RID: 626
	public float coolDown;

	// Token: 0x04000273 RID: 627
	public float waitTime;

	// Token: 0x04000274 RID: 628
	public int wanders;

	// Token: 0x04000275 RID: 629
	public bool active;

	// Token: 0x04000276 RID: 630
	private Vector3 origin;

	// Token: 0x04000277 RID: 631
	public AudioClip aud_Sweep;

	// Token: 0x04000278 RID: 632
	public AudioClip aud_Intro;

	// Token: 0x04000279 RID: 633
	private NavMeshAgent agent;

	// Token: 0x0400027A RID: 634
	private AudioSource audioDevice;
}
