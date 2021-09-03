using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200002F RID: 47
public class CraftersScript : MonoBehaviour
{
	// Token: 0x060000C1 RID: 193 RVA: 0x0000462D File Offset: 0x0000282D
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.audioDevice = base.GetComponent<AudioSource>();
		this.sprite.SetActive(false);
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00004654 File Offset: 0x00002854
	private void Update()
	{
		if (this.forceShowTime > 0f)
		{
			this.forceShowTime -= Time.deltaTime;
		}
		if (this.gettingAngry)
		{
			this.anger += Time.deltaTime;
			if (this.anger >= 1f & !this.angry)
			{
				this.angry = true;
				this.audioDevice.PlayOneShot(this.aud_Intro);
				this.spriteImage.sprite = this.angrySprite;
			}
		}
		else if (this.anger > 0f)
		{
			this.anger -= Time.deltaTime;
		}
		if (this.angry)
		{
			this.agent.speed = this.agent.speed + 60f * Time.deltaTime;
			this.TargetPlayer();
			if (!this.audioDevice.isPlaying)
			{
				this.audioDevice.PlayOneShot(this.aud_Loop);
			}
			return;
		}
		if (((base.transform.position - this.agent.destination).magnitude <= 20f & (base.transform.position - this.player.position).magnitude >= 60f) || this.forceShowTime > 0f)
		{
			this.sprite.SetActive(true);
			return;
		}
		this.sprite.SetActive(false);
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x000047D8 File Offset: 0x000029D8
	private void FixedUpdate()
	{
		if (this.gc.notebooks >= 7)
		{
			Vector3 direction = this.player.position - base.transform.position;
			RaycastHit raycastHit;
			if (Physics.Raycast(base.transform.position + Vector3.up * 2f, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player" & this.craftersRenderer.isVisible & this.sprite.activeSelf)
			{
				this.gettingAngry = true;
				return;
			}
			this.gettingAngry = false;
		}
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00004880 File Offset: 0x00002A80
	public void GiveLocation(Vector3 location, bool flee)
	{
		if (!this.angry)
		{
			this.agent.SetDestination(location);
			if (flee)
			{
				this.forceShowTime = 3f;
			}
		}
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x000048A5 File Offset: 0x00002AA5
	private void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x000048C0 File Offset: 0x00002AC0
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" & this.angry)
		{
			this.player.position = new Vector3(5f, this.player.position.y, 80f);
			this.baldiAgent.Warp(new Vector3(5f, this.baldi.position.y, 125f));
			this.player.LookAt(new Vector3(this.baldi.position.x, this.player.position.y, this.baldi.position.z));
			this.gc.DespawnCrafters();
		}
	}

	// Token: 0x040000E6 RID: 230
	public bool db;

	// Token: 0x040000E7 RID: 231
	public bool angry;

	// Token: 0x040000E8 RID: 232
	public bool gettingAngry;

	// Token: 0x040000E9 RID: 233
	public float anger;

	// Token: 0x040000EA RID: 234
	private float forceShowTime;

	// Token: 0x040000EB RID: 235
	public Transform player;

	// Token: 0x040000EC RID: 236
	public Transform playerCamera;

	// Token: 0x040000ED RID: 237
	public Transform baldi;

	// Token: 0x040000EE RID: 238
	public NavMeshAgent baldiAgent;

	// Token: 0x040000EF RID: 239
	public GameObject sprite;

	// Token: 0x040000F0 RID: 240
	public GameControllerScript gc;

	// Token: 0x040000F1 RID: 241
	private NavMeshAgent agent;

	// Token: 0x040000F2 RID: 242
	public Renderer craftersRenderer;

	// Token: 0x040000F3 RID: 243
	public SpriteRenderer spriteImage;

	// Token: 0x040000F4 RID: 244
	public Sprite angrySprite;

	// Token: 0x040000F5 RID: 245
	private AudioSource audioDevice;

	// Token: 0x040000F6 RID: 246
	public AudioClip aud_Intro;

	// Token: 0x040000F7 RID: 247
	public AudioClip aud_Loop;
}
