using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200003C RID: 60
public class FirstPrizeScript : MonoBehaviour
{
	// Token: 0x060000F5 RID: 245 RVA: 0x00004F8B File Offset: 0x0000318B
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.coolDown = 1f;
		this.Wander();
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x00004FAC File Offset: 0x000031AC
	private void Update()
	{
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.autoBrakeCool > 0f)
		{
			this.autoBrakeCool -= 1f * Time.deltaTime;
		}
		else
		{
			this.agent.autoBraking = true;
		}
		this.angleDiff = Mathf.DeltaAngle(base.transform.eulerAngles.y, Mathf.Atan2(this.agent.steeringTarget.x - base.transform.position.x, this.agent.steeringTarget.z - base.transform.position.z) * 57.29578f);
		if (this.crazyTime <= 0f)
		{
			if (Mathf.Abs(this.angleDiff) < 5f)
			{
				base.transform.LookAt(new Vector3(this.agent.steeringTarget.x, base.transform.position.y, this.agent.steeringTarget.z));
				this.agent.speed = this.currentSpeed;
			}
			else
			{
				base.transform.Rotate(new Vector3(0f, this.turnSpeed * Mathf.Sign(this.angleDiff) * Time.deltaTime, 0f));
				this.agent.speed = 0f;
			}
		}
		else
		{
			this.agent.speed = 0f;
			base.transform.Rotate(new Vector3(0f, 180f * Time.deltaTime, 0f));
			this.crazyTime -= Time.deltaTime;
		}
		this.motorAudio.pitch = (this.agent.velocity.magnitude + 1f) * Time.timeScale;
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x000051A8 File Offset: 0x000033A8
	private void FixedUpdate()
	{
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player")
		{
			if (!this.playerSeen && !this.audioDevice.isPlaying)
			{
				int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.audioDevice.PlayOneShot(this.aud_Found[num]);
			}
			this.playerSeen = true;
			this.TargetPlayer();
			this.currentSpeed = this.runSpeed;
			return;
		}
		this.currentSpeed = this.normSpeed;
		if (this.playerSeen & this.coolDown <= 0f)
		{
			if (!this.audioDevice.isPlaying)
			{
				int num2 = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.audioDevice.PlayOneShot(this.aud_Lost[num2]);
			}
			this.playerSeen = false;
			this.Wander();
			return;
		}
		if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f & (base.transform.position - this.agent.destination).magnitude < 5f)
		{
			this.Wander();
		}
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x00005328 File Offset: 0x00003528
	private void Wander()
	{
		this.wanderer.GetNewTargetHallway();
		this.agent.SetDestination(this.wanderTarget.position);
		this.hugAnnounced = false;
		int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 9f));
		if (!this.audioDevice.isPlaying & num == 0 & this.coolDown <= 0f)
		{
			int num2 = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
			this.audioDevice.PlayOneShot(this.aud_Random[num2]);
		}
		this.coolDown = 1f;
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x000053CC File Offset: 0x000035CC
	private void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
		this.coolDown = 0.5f;
	}

	// Token: 0x060000FA RID: 250 RVA: 0x000053F0 File Offset: 0x000035F0
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!this.audioDevice.isPlaying & !this.hugAnnounced)
			{
				int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.audioDevice.PlayOneShot(this.aud_Hug[num]);
				this.hugAnnounced = true;
			}
			this.agent.autoBraking = false;
		}
	}

	// Token: 0x060000FB RID: 251 RVA: 0x00005464 File Offset: 0x00003664
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.autoBrakeCool = 1f;
		}
	}

	// Token: 0x060000FC RID: 252 RVA: 0x00005483 File Offset: 0x00003683
	public void GoCrazy()
	{
		this.crazyTime = 15f;
	}

	// Token: 0x0400011E RID: 286
	public float debug;

	// Token: 0x0400011F RID: 287
	public float turnSpeed;

	// Token: 0x04000120 RID: 288
	public float str;

	// Token: 0x04000121 RID: 289
	public float angleDiff;

	// Token: 0x04000122 RID: 290
	public float normSpeed;

	// Token: 0x04000123 RID: 291
	public float runSpeed;

	// Token: 0x04000124 RID: 292
	public float currentSpeed;

	// Token: 0x04000125 RID: 293
	public float acceleration;

	// Token: 0x04000126 RID: 294
	public float speed;

	// Token: 0x04000127 RID: 295
	public float autoBrakeCool;

	// Token: 0x04000128 RID: 296
	public float crazyTime;

	// Token: 0x04000129 RID: 297
	public Quaternion targetRotation;

	// Token: 0x0400012A RID: 298
	public float coolDown;

	// Token: 0x0400012B RID: 299
	public bool playerSeen;

	// Token: 0x0400012C RID: 300
	public bool hugAnnounced;

	// Token: 0x0400012D RID: 301
	public AILocationSelectorScript wanderer;

	// Token: 0x0400012E RID: 302
	public Transform player;

	// Token: 0x0400012F RID: 303
	public Transform wanderTarget;

	// Token: 0x04000130 RID: 304
	public AudioClip[] aud_Found = new AudioClip[2];

	// Token: 0x04000131 RID: 305
	public AudioClip[] aud_Lost = new AudioClip[2];

	// Token: 0x04000132 RID: 306
	public AudioClip[] aud_Hug = new AudioClip[2];

	// Token: 0x04000133 RID: 307
	public AudioClip[] aud_Random = new AudioClip[2];

	// Token: 0x04000134 RID: 308
	public AudioSource audioDevice;

	// Token: 0x04000135 RID: 309
	public AudioSource motorAudio;

	// Token: 0x04000136 RID: 310
	private NavMeshAgent agent;
}
