using System;
using UnityEngine;

// Token: 0x0200002C RID: 44
public class BullyScript : MonoBehaviour
{
	// Token: 0x060000B3 RID: 179 RVA: 0x00003F25 File Offset: 0x00002125
	private void Start()
	{
		this.audioDevice = base.GetComponent<AudioSource>();
		this.waitTime = UnityEngine.Random.Range(60f, 120f);
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00003F48 File Offset: 0x00002148
	private void Update()
	{
		if (this.waitTime > 0f)
		{
			this.waitTime -= Time.deltaTime;
		}
		else if (!this.active)
		{
			this.Activate();
		}
		if (this.active)
		{
			this.activeTime += Time.deltaTime;
			if (this.activeTime >= 180f & (base.transform.position - this.player.position).magnitude >= 120f)
			{
				this.Reset();
			}
		}
		if (this.guilt > 0f)
		{
			this.guilt -= Time.deltaTime;
		}
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00004004 File Offset: 0x00002204
	private void FixedUpdate()
	{
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position + new Vector3(0f, 4f, 0f), direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player" & this.bullyRenderer.isVisible & (base.transform.position - this.player.position).magnitude <= 30f & this.active)
		{
			if (!this.spoken)
			{
				int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.audioDevice.PlayOneShot(this.aud_Taunts[num]);
				this.spoken = true;
			}
			this.guilt = 10f;
		}
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x000040FC File Offset: 0x000022FC
	private void Activate()
	{
		this.wanderer.GetNewTargetHallway();
		base.transform.position = this.wanderTarget.position + new Vector3(0f, 5f, 0f);
		while ((base.transform.position - this.player.position).magnitude < 20f)
		{
			this.wanderer.GetNewTargetHallway();
			base.transform.position = this.wanderTarget.position + new Vector3(0f, 5f, 0f);
		}
		this.active = true;
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x000041B0 File Offset: 0x000023B0
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			if (this.gc.item[0] == 0 & this.gc.item[1] == 0 & this.gc.item[2] == 0)
			{
				this.audioDevice.PlayOneShot(this.aud_Denied);
			}
			else
			{
				int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 2f));
				while (this.gc.item[num] == 0)
				{
					num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 2f));
				}
				this.gc.LoseItem(num);
				int num2 = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.audioDevice.PlayOneShot(this.aud_Thanks[num2]);
				this.Reset();
			}
		}
		if (other.transform.name == "Principal of the Thing" & this.guilt > 0f)
		{
			this.Reset();
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x000042C0 File Offset: 0x000024C0
	private void Reset()
	{
		base.transform.position = base.transform.position - new Vector3(0f, 20f, 0f);
		this.waitTime = UnityEngine.Random.Range(60f, 120f);
		this.active = false;
		this.activeTime = 0f;
		this.spoken = false;
	}

	// Token: 0x040000CE RID: 206
	public Transform player;

	// Token: 0x040000CF RID: 207
	public GameControllerScript gc;

	// Token: 0x040000D0 RID: 208
	public Renderer bullyRenderer;

	// Token: 0x040000D1 RID: 209
	public Transform wanderTarget;

	// Token: 0x040000D2 RID: 210
	public AILocationSelectorScript wanderer;

	// Token: 0x040000D3 RID: 211
	public float waitTime;

	// Token: 0x040000D4 RID: 212
	public float activeTime;

	// Token: 0x040000D5 RID: 213
	public float guilt;

	// Token: 0x040000D6 RID: 214
	public bool active;

	// Token: 0x040000D7 RID: 215
	public bool spoken;

	// Token: 0x040000D8 RID: 216
	private AudioSource audioDevice;

	// Token: 0x040000D9 RID: 217
	public AudioClip[] aud_Taunts = new AudioClip[2];

	// Token: 0x040000DA RID: 218
	public AudioClip[] aud_Thanks = new AudioClip[2];

	// Token: 0x040000DB RID: 219
	public AudioClip aud_Denied;
}
