using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200004D RID: 77
public class PrincipalScript : MonoBehaviour
{
	// Token: 0x06000160 RID: 352 RVA: 0x00008D71 File Offset: 0x00006F71
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.audioQueue = base.GetComponent<AudioQueueScript>();
		this.audioDevice = base.GetComponent<AudioSource>();
	}

	// Token: 0x06000161 RID: 353 RVA: 0x00008D98 File Offset: 0x00006F98
	private void Update()
	{
		if (this.seesRuleBreak)
		{
			this.timeSeenRuleBreak += 1f * Time.deltaTime;
			if ((double)this.timeSeenRuleBreak >= 0.5 & !this.angry)
			{
				this.angry = true;
				this.seesRuleBreak = false;
				this.timeSeenRuleBreak = 0f;
				this.TargetPlayer();
				this.CorrectPlayer();
			}
		}
		else
		{
			this.timeSeenRuleBreak = 0f;
		}
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.blindnessMoment & this.blindTime > 0f)
		{
			this.blindTime -= Time.deltaTime;
		}
		if (this.blindTime <= 0f & this.blindnessMoment)
		{
			this.TargetBully();
		}
	}

	// Token: 0x06000162 RID: 354 RVA: 0x00008E84 File Offset: 0x00007084
	private void FixedUpdate()
	{
		if (!this.angry)
		{
			Vector3 direction = this.player.position - base.transform.position;
			RaycastHit raycastHit;
			if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player" & this.playerScript.guilt > 0f & !this.inOffice & !this.angry)
			{
				this.seesRuleBreak = true;
			}
			else
			{
				this.seesRuleBreak = false;
				if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f)
				{
					this.Wander();
				}
			}
			direction = this.Prankster.position - base.transform.position;
			if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3) & raycastHit.transform.name == "Prankster" & this.bullyScript.guilt > 0f & !this.inOffice & !this.angry)
			{
				this.TargetBully();
				return;
			}
		}
		else
		{
			this.TargetPlayer();
		}
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00008FDC File Offset: 0x000071DC
	public void Wander()
	{
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		if (this.agent.isStopped)
		{
			this.agent.isStopped = false;
		}
		this.coolDown = 1f;
		if (UnityEngine.Random.Range(0f, 10f) <= 1f)
		{
			this.quietAudioDevice.PlayOneShot(this.aud_Whistle);
		}
	}

	// Token: 0x06000164 RID: 356 RVA: 0x00009056 File Offset: 0x00007256
	public void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
		this.coolDown = 1f;
	}

	// Token: 0x06000165 RID: 357 RVA: 0x0000907A File Offset: 0x0000727A
	private void TargetBully()
	{
		if (!this.bullySeen)
		{
			this.agent.SetDestination(this.Prankster.position);
			this.audioQueue.QueueAudio(this.audNoBullying);
			this.bullySeen = true;
		}
	}

	// Token: 0x06000166 RID: 358 RVA: 0x000090B4 File Offset: 0x000072B4
	private void CorrectPlayer()
	{
		this.audioQueue.ClearAudioQueue();
		if (this.playerScript.guiltType == "faculty")
		{
			this.audioQueue.QueueAudio(this.audNoFaculty);
			return;
		}
		if (this.playerScript.guiltType == "running")
		{
			this.audioQueue.QueueAudio(this.audNoRunning);
			return;
		}
		if (this.playerScript.guiltType == "drink")
		{
			this.audioQueue.QueueAudio(this.audNoDrinking);
			return;
		}
		if (this.playerScript.guiltType == "escape")
		{
			this.audioQueue.QueueAudio(this.audNoEscaping);
			return;
		}
		if (this.playerScript.guiltType == "Annoyance")
		{
			this.audioQueue.QueueAudio(this.aud_NoWindow);
		}
	}

	// Token: 0x06000167 RID: 359 RVA: 0x00009198 File Offset: 0x00007398
	private void OnTriggerStay(Collider other)
	{
		if (other.name == "Office Trigger")
		{
			this.inOffice = true;
		}
		if (other.tag == "Player" & this.angry & !this.inOffice)
		{
			this.inOffice = true;
			this.agent.Warp(new Vector3(-2763f, 4f, 113f));
			this.agent.isStopped = true;
			other.transform.position = new Vector3(-2766.6f, 4f, 116.7f);
			other.transform.LookAt(new Vector3(base.transform.position.x, other.transform.position.y, base.transform.position.z));
			this.audioQueue.QueueAudio(this.aud_Delay);
			this.audioQueue.QueueAudio(this.audTimes[this.detentions]);
			this.audioQueue.QueueAudio(this.audDetention);
			int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 2f));
			this.audioQueue.QueueAudio(this.audScolds[num]);
			this.officeDoor.LockDoor((float)this.lockTime[this.detentions]);
			this.baldiScript.Hear(base.transform.position, 5f);
			this.coolDown = 5f;
			this.angry = false;
			this.detentions++;
			if (this.detentions > 4)
			{
				this.detentions = 4;
			}
		}
		if (other.transform.name == "blindingObject(Clone)")
		{
			this.blindTime = 15f;
			this.agent.isStopped = true;
		}
	}

	// Token: 0x06000168 RID: 360 RVA: 0x0000936A File Offset: 0x0000756A
	private void OnTriggerExit(Collider other)
	{
		if (other.name == "Office Trigger")
		{
			this.inOffice = false;
		}
		if (other.name == "Prankster")
		{
			this.bullySeen = false;
		}
	}

	// Token: 0x04000240 RID: 576
	public bool seesRuleBreak;

	// Token: 0x04000241 RID: 577
	public Transform player;

	// Token: 0x04000242 RID: 578
	public Transform Prankster;

	// Token: 0x04000243 RID: 579
	public bool bullySeen;

	// Token: 0x04000244 RID: 580
	public PlayerScript playerScript;

	// Token: 0x04000245 RID: 581
	public PranksterScript bullyScript;

	// Token: 0x04000246 RID: 582
	public BaldiScript baldiScript;

	// Token: 0x04000247 RID: 583
	public Transform wanderTarget;

	// Token: 0x04000248 RID: 584
	public AILocationSelectorScript wanderer;

	// Token: 0x04000249 RID: 585
	public DoorScript officeDoor;

	// Token: 0x0400024A RID: 586
	public float coolDown;

	// Token: 0x0400024B RID: 587
	public float timeSeenRuleBreak;

	// Token: 0x0400024C RID: 588
	public bool angry;

	// Token: 0x0400024D RID: 589
	public bool inOffice;

	// Token: 0x0400024E RID: 590
	private int detentions;

	// Token: 0x0400024F RID: 591
	private int[] lockTime = new int[]
	{
		15,
		30,
		45,
		60,
		99,
		1000
	};

	// Token: 0x04000250 RID: 592
	public AudioClip[] audTimes = new AudioClip[5];

	// Token: 0x04000251 RID: 593
	public AudioClip[] audScolds = new AudioClip[3];

	// Token: 0x04000252 RID: 594
	public AudioClip audDetention;

	// Token: 0x04000253 RID: 595
	public AudioClip audNoDrinking;

	// Token: 0x04000254 RID: 596
	public AudioClip audNoBullying;

	// Token: 0x04000255 RID: 597
	public AudioClip audNoFaculty;

	// Token: 0x04000256 RID: 598
	public AudioClip audNoLockers;

	// Token: 0x04000257 RID: 599
	public AudioClip audNoRunning;

	// Token: 0x04000258 RID: 600
	public AudioClip audNoStabbing;

	// Token: 0x04000259 RID: 601
	public AudioClip audNoEscaping;

	// Token: 0x0400025A RID: 602
	public AudioClip aud_Whistle;

	// Token: 0x0400025B RID: 603
	public float blindTime;

	// Token: 0x0400025C RID: 604
	public AudioClip aud_Delay;

	// Token: 0x0400025D RID: 605
	public NavMeshAgent agent;

	// Token: 0x0400025E RID: 606
	private AudioQueueScript audioQueue;

	// Token: 0x0400025F RID: 607
	private AudioSource audioDevice;

	// Token: 0x04000260 RID: 608
	public AudioSource quietAudioDevice;

	// Token: 0x04000261 RID: 609
	public AudioClip aud_NoWindow;

	// Token: 0x04000262 RID: 610
	public Sprite Fear;

	// Token: 0x04000263 RID: 611
	public Sprite Normal;

	// Token: 0x04000264 RID: 612
	public bool blindnessMoment;
}
