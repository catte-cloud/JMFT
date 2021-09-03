using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000027 RID: 39
public class BaldiScript : MonoBehaviour
{
	// Token: 0x06000099 RID: 153 RVA: 0x00003914 File Offset: 0x00001B14
	private void Start()
	{
		this.baldiAudio = base.GetComponent<AudioSource>();
		this.agent = base.GetComponent<NavMeshAgent>();
		this.timeToMove = this.baseTime;
		this.Wander();
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00003940 File Offset: 0x00001B40
	private void Update()
	{
		if (this.timeToMove > 0f)
		{
			this.timeToMove -= 1f * Time.deltaTime;
		}
		else
		{
			this.Move();
		}
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.baldiTempAnger > 0f)
		{
			this.baldiTempAnger -= 0.02f * Time.deltaTime;
		}
		else
		{
			this.baldiTempAnger = 0f;
		}
		if (this.antiHearingTime > 0f)
		{
			this.antiHearingTime -= Time.deltaTime;
		}
		else
		{
			this.antiHearing = false;
		}
		if (this.endless)
		{
			if (this.timeToAnger > 0f)
			{
				this.timeToAnger -= 1f * Time.deltaTime;
				return;
			}
			this.timeToAnger = this.angerFrequency;
			this.GetAngry(this.angerRate);
			this.angerRate += this.angerRateRate;
		}
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00003A54 File Offset: 0x00001C54
	private void FixedUpdate()
	{
		if (this.moveFrames > 0f)
		{
			this.moveFrames -= 1f;
			this.agent.speed = this.speed;
		}
		else
		{
			this.agent.speed = 0f;
		}
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position + Vector3.up * 2f, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player")
		{
			this.db = true;
			this.TargetPlayer();
			return;
		}
		this.db = false;
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00003B1B File Offset: 0x00001D1B
	private void Wander()
	{
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 1f;
		this.currentPriority = 0f;
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00003B55 File Offset: 0x00001D55
	public void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
		this.coolDown = 1f;
		this.currentPriority = 0f;
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00003B84 File Offset: 0x00001D84
	private void Move()
	{
		if (base.transform.position == this.previous & this.coolDown < 0f)
		{
			this.Wander();
		}
		this.moveFrames = 10f;
		this.timeToMove = this.baldiWait - this.baldiTempAnger;
		this.previous = base.transform.position;
		this.baldiAudio.PlayOneShot(this.slap);
		this.baldiAnimator.SetTrigger("slap");
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00003C10 File Offset: 0x00001E10
	public void GetAngry(float value)
	{
		this.baldiAnger += value;
		if (this.baldiAnger < 0.5f)
		{
			this.baldiAnger = 0.5f;
		}
		this.baldiWait = -3f * this.baldiAnger / (this.baldiAnger + 2f / this.baldiSpeedScale) + 3f;
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00003C6F File Offset: 0x00001E6F
	public void GetTempAngry(float value)
	{
		this.baldiTempAnger += value;
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x00003C7F File Offset: 0x00001E7F
	public void Hear(Vector3 soundLocation, float priority)
	{
		if (!this.antiHearing && priority >= this.currentPriority)
		{
			this.agent.SetDestination(soundLocation);
			this.currentPriority = priority;
		}
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x00003CA6 File Offset: 0x00001EA6
	public void ActivateAntiHearing(float t)
	{
		this.Wander();
		this.antiHearing = true;
		this.antiHearingTime = t;
	}

	// Token: 0x040000A9 RID: 169
	public bool db;

	// Token: 0x040000AA RID: 170
	public float baseTime;

	// Token: 0x040000AB RID: 171
	public float speed;

	// Token: 0x040000AC RID: 172
	public float timeToMove;

	// Token: 0x040000AD RID: 173
	public float baldiAnger;

	// Token: 0x040000AE RID: 174
	public float baldiTempAnger;

	// Token: 0x040000AF RID: 175
	public float baldiWait;

	// Token: 0x040000B0 RID: 176
	public float baldiSpeedScale;

	// Token: 0x040000B1 RID: 177
	private float moveFrames;

	// Token: 0x040000B2 RID: 178
	private float currentPriority;

	// Token: 0x040000B3 RID: 179
	public bool antiHearing;

	// Token: 0x040000B4 RID: 180
	public float antiHearingTime;

	// Token: 0x040000B5 RID: 181
	public float angerRate;

	// Token: 0x040000B6 RID: 182
	public float angerRateRate;

	// Token: 0x040000B7 RID: 183
	public float angerFrequency;

	// Token: 0x040000B8 RID: 184
	public float timeToAnger;

	// Token: 0x040000B9 RID: 185
	public bool endless;

	// Token: 0x040000BA RID: 186
	public Transform player;

	// Token: 0x040000BB RID: 187
	public Transform wanderTarget;

	// Token: 0x040000BC RID: 188
	public AILocationSelectorScript wanderer;

	// Token: 0x040000BD RID: 189
	private AudioSource baldiAudio;

	// Token: 0x040000BE RID: 190
	public AudioClip slap;

	// Token: 0x040000BF RID: 191
	public AudioClip[] speech = new AudioClip[3];

	// Token: 0x040000C0 RID: 192
	public Animator baldiAnimator;

	// Token: 0x040000C1 RID: 193
	public float coolDown;

	// Token: 0x040000C2 RID: 194
	private Vector3 previous;

	// Token: 0x040000C3 RID: 195
	private NavMeshAgent agent;
}
