using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200004A RID: 74
public class PlaytimeScript : MonoBehaviour
{
	// Token: 0x06000153 RID: 339 RVA: 0x00008902 File Offset: 0x00006B02
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.audioDevice = base.GetComponent<AudioSource>();
		this.Wander();
	}

	// Token: 0x06000154 RID: 340 RVA: 0x00008924 File Offset: 0x00006B24
	private void Update()
	{
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.playCool >= 0f)
		{
			this.playCool -= Time.deltaTime;
			return;
		}
		if (this.animator.GetBool("disappointed"))
		{
			this.playCool = 0f;
			this.animator.SetBool("disappointed", false);
		}
	}

	// Token: 0x06000155 RID: 341 RVA: 0x000089A4 File Offset: 0x00006BA4
	private void FixedUpdate()
	{
		if (!this.ps.jumpRope)
		{
			Vector3 direction = this.player.position - base.transform.position;
			RaycastHit raycastHit;
			if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player" & (base.transform.position - this.player.position).magnitude <= 80f & this.playCool <= 0f)
			{
				this.playerSeen = true;
				this.TargetPlayer();
			}
			else if (this.playerSeen & this.coolDown <= 0f)
			{
				this.playerSeen = false;
				this.Wander();
			}
			else if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f)
			{
				this.Wander();
			}
			this.jumpRopeStarted = false;
			return;
		}
		if (!this.jumpRopeStarted)
		{
			this.agent.Warp(base.transform.position - base.transform.forward * 10f);
		}
		this.jumpRopeStarted = true;
		this.agent.speed = 0f;
		this.playCool = 15f;
	}

	// Token: 0x06000156 RID: 342 RVA: 0x00008B20 File Offset: 0x00006D20
	private void Wander()
	{
		this.wanderer.GetNewTargetHallway();
		this.agent.SetDestination(this.wanderTarget.position);
		this.agent.speed = 15f;
		this.playerSpotted = false;
		this.audVal = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
		if (!this.audioDevice.isPlaying)
		{
			this.audioDevice.PlayOneShot(this.aud_Random[this.audVal]);
		}
		this.coolDown = 1f;
	}

	// Token: 0x06000157 RID: 343 RVA: 0x00008BB0 File Offset: 0x00006DB0
	private void TargetPlayer()
	{
		this.animator.SetBool("disappointed", false);
		this.agent.SetDestination(this.player.position);
		this.agent.speed = 20f;
		this.coolDown = 0.2f;
		if (!this.playerSpotted)
		{
			this.playerSpotted = true;
			this.audioDevice.PlayOneShot(this.aud_LetsPlay);
		}
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00008C20 File Offset: 0x00006E20
	public void Disappoint()
	{
		this.animator.SetBool("disappointed", true);
		this.audioDevice.Stop();
		this.audioDevice.PlayOneShot(this.aud_Sad);
	}

	// Token: 0x0400021B RID: 539
	public bool db;

	// Token: 0x0400021C RID: 540
	public bool playerSeen;

	// Token: 0x0400021D RID: 541
	public bool disappointed;

	// Token: 0x0400021E RID: 542
	public int audVal;

	// Token: 0x0400021F RID: 543
	public Animator animator;

	// Token: 0x04000220 RID: 544
	public Transform player;

	// Token: 0x04000221 RID: 545
	public PlayerScript ps;

	// Token: 0x04000222 RID: 546
	public Transform wanderTarget;

	// Token: 0x04000223 RID: 547
	public AILocationSelectorScript wanderer;

	// Token: 0x04000224 RID: 548
	public float coolDown;

	// Token: 0x04000225 RID: 549
	public float playCool;

	// Token: 0x04000226 RID: 550
	public bool playerSpotted;

	// Token: 0x04000227 RID: 551
	public bool jumpRopeStarted;

	// Token: 0x04000228 RID: 552
	private NavMeshAgent agent;

	// Token: 0x04000229 RID: 553
	public AudioClip[] aud_Numbers = new AudioClip[10];

	// Token: 0x0400022A RID: 554
	public AudioClip[] aud_Random = new AudioClip[2];

	// Token: 0x0400022B RID: 555
	public AudioClip aud_Instrcutions;

	// Token: 0x0400022C RID: 556
	public AudioClip aud_Oops;

	// Token: 0x0400022D RID: 557
	public AudioClip aud_LetsPlay;

	// Token: 0x0400022E RID: 558
	public AudioClip aud_Congrats;

	// Token: 0x0400022F RID: 559
	public AudioClip aud_ReadyGo;

	// Token: 0x04000230 RID: 560
	public AudioClip aud_Sad;

	// Token: 0x04000231 RID: 561
	public AudioSource audioDevice;
}
