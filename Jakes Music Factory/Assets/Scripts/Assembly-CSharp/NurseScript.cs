using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200001A RID: 26
public class NurseScript : MonoBehaviour
{
	// Token: 0x0600005B RID: 91 RVA: 0x000029DE File Offset: 0x00000BDE
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.audioDevice = base.GetComponent<AudioSource>();
		this.Wander();
		this.spriterend.sprite = this.Normal;
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00002A10 File Offset: 0x00000C10
	private void Update()
	{
		if (this.player.stamina <= 0f)
		{
			this.nostamina = true;
			this.agent.speed = 30f;
			this.TargetPlayer();
			this.spriterend.sprite = this.Target;
			this.audioDevice.PlayOneShot(this.aud_rest);
		}
		else
		{
			if (this.agent.velocity.magnitude <= 1f)
			{
				this.Wander();
			}
			this.nostamina = false;
			this.agent.speed = 5f;
			this.spriterend.sprite = this.Normal;
		}
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.player.blindnessMoment)
		{
			this.agent.speed = 10f;
			this.TargetPlayer();
			this.spriterend.sprite = this.Target;
			this.audioDevice.PlayOneShot(this.aud_rest);
			this.pieface = true;
			return;
		}
		this.pieface = false;
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00002B34 File Offset: 0x00000D34
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" & this.nostamina)
		{
			this.player.stamina = 200f;
			this.agent.Warp(new Vector3(-2953.6f, 4f, 114.7f));
			other.transform.position = new Vector3(-2953.6f, 4f, 114.7f);
			this.audioDevice.PlayOneShot(this.aud_Safe);
		}
		if (other.tag == "Player" & this.pieface)
		{
			this.player.blindTime = 0f;
			this.audioDevice.PlayOneShot(this.aud_Safe);
			this.player.blindScreen.SetActive(false);
			this.pieface = false;
		}
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00002C0C File Offset: 0x00000E0C
	public void Wander()
	{
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 1f;
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00002C3B File Offset: 0x00000E3B
	public void TargetPlayer()
	{
		this.agent.SetDestination(this.playertrans.position);
		this.coolDown = 1f;
	}

	// Token: 0x0400003E RID: 62
	public Transform wanderTarget;

	// Token: 0x0400003F RID: 63
	public AILocationSelectorScript wanderer;

	// Token: 0x04000040 RID: 64
	public float coolDown;

	// Token: 0x04000041 RID: 65
	public Sprite Target;

	// Token: 0x04000042 RID: 66
	public Sprite Normal;

	// Token: 0x04000043 RID: 67
	private AudioSource audioDevice;

	// Token: 0x04000044 RID: 68
	public NavMeshAgent agent;

	// Token: 0x04000045 RID: 69
	public PlayerScript player;

	// Token: 0x04000046 RID: 70
	public Transform playertrans;

	// Token: 0x04000047 RID: 71
	public bool nostamina;

	// Token: 0x04000048 RID: 72
	public bool pieface;

	// Token: 0x04000049 RID: 73
	public SpriteRenderer spriterend;

	// Token: 0x0400004A RID: 74
	public AudioClip aud_Safe;

	// Token: 0x0400004B RID: 75
	public AudioClip aud_rest;

	// Token: 0x0400004C RID: 76
	public AudioSource scream;
}
