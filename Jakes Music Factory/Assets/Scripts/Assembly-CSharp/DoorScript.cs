using System;
using UnityEngine;

// Token: 0x02000035 RID: 53
public class DoorScript : MonoBehaviour
{
	// Token: 0x060000DB RID: 219 RVA: 0x00004AD3 File Offset: 0x00002CD3
	private void Start()
	{
		this.myAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00004AE4 File Offset: 0x00002CE4
	private void Update()
	{
		if (this.lockTime > 0f)
		{
			this.lockTime -= 1f * Time.deltaTime;
		}
		else if (this.bDoorLocked)
		{
			this.UnlockDoor();
		}
		if (this.openTime > 0f)
		{
			this.openTime -= 1f * Time.deltaTime;
		}
		if (this.openTime <= 0f & this.bDoorOpen)
		{
			this.barrier.enabled = true;
			this.invisibleBarrier.enabled = true;
			this.bDoorOpen = false;
			this.inside.sharedMaterial = this.closed;
			this.outside.sharedMaterial = this.closed;
			if (this.silentOpens <= 0)
			{
				this.myAudio.PlayOneShot(this.doorClose, 1f);
			}
		}
		RaycastHit raycastHit;
		if ((Input.GetMouseButtonDown(0) & Time.timeScale != 0f) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit) && (raycastHit.collider == this.trigger & Vector3.Distance(this.player.position, base.transform.position) < this.openingDistance & !this.bDoorLocked))
		{
			if (this.baldi.isActiveAndEnabled & this.silentOpens <= 0)
			{
				this.baldi.Hear(base.transform.position, 1f);
			}
			this.OpenDoor();
			if (this.silentOpens > 0)
			{
				this.silentOpens--;
			}
		}
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00004C90 File Offset: 0x00002E90
	public void OpenDoor()
	{
		if (this.silentOpens <= 0 && !this.bDoorOpen)
		{
			this.myAudio.PlayOneShot(this.doorOpen, 1f);
		}
		this.barrier.enabled = false;
		this.invisibleBarrier.enabled = false;
		this.bDoorOpen = true;
		this.inside.sharedMaterial = this.open;
		this.outside.sharedMaterial = this.open;
		this.openTime = 3f;
	}

	// Token: 0x060000DE RID: 222 RVA: 0x00004D10 File Offset: 0x00002F10
	private void OnTriggerStay(Collider other)
	{
		if (!this.bDoorLocked & other.CompareTag("NPC"))
		{
			this.OpenDoor();
		}
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00004D2F File Offset: 0x00002F2F
	public void LockDoor(float time)
	{
		this.bDoorLocked = true;
		this.lockTime = time;
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00004D3F File Offset: 0x00002F3F
	public void UnlockDoor()
	{
		this.bDoorLocked = false;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00004D48 File Offset: 0x00002F48
	public void SilenceDoor()
	{
		this.silentOpens = 4;
	}

	// Token: 0x040000FF RID: 255
	public float openingDistance;

	// Token: 0x04000100 RID: 256
	public Transform player;

	// Token: 0x04000101 RID: 257
	public BaldiScript baldi;

	// Token: 0x04000102 RID: 258
	public MeshCollider barrier;

	// Token: 0x04000103 RID: 259
	public MeshCollider trigger;

	// Token: 0x04000104 RID: 260
	public MeshCollider invisibleBarrier;

	// Token: 0x04000105 RID: 261
	public MeshRenderer inside;

	// Token: 0x04000106 RID: 262
	public MeshRenderer outside;

	// Token: 0x04000107 RID: 263
	public AudioClip doorOpen;

	// Token: 0x04000108 RID: 264
	public AudioClip doorClose;

	// Token: 0x04000109 RID: 265
	public Material closed;

	// Token: 0x0400010A RID: 266
	public Material open;

	// Token: 0x0400010B RID: 267
	private bool bDoorOpen;

	// Token: 0x0400010C RID: 268
	private bool bDoorLocked;

	// Token: 0x0400010D RID: 269
	public int silentOpens;

	// Token: 0x0400010E RID: 270
	private float openTime;

	// Token: 0x0400010F RID: 271
	public float lockTime;

	// Token: 0x04000110 RID: 272
	private AudioSource myAudio;
}
