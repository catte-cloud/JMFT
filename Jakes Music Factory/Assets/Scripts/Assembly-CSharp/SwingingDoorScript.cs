using System;
using UnityEngine;

// Token: 0x02000056 RID: 86
public class SwingingDoorScript : MonoBehaviour
{
	// Token: 0x06000189 RID: 393 RVA: 0x000097F0 File Offset: 0x000079F0
	private void Start()
	{
		this.myAudio = base.GetComponent<AudioSource>();
		this.bDoorLocked = true;
	}

	// Token: 0x0600018A RID: 394 RVA: 0x00009808 File Offset: 0x00007A08
	private void Update()
	{
		if (!this.requirementMet & this.gc.notebooks >= 0)
		{
			this.requirementMet = true;
			this.UnlockDoor();
		}
		if (this.openTime > 0f)
		{
			this.openTime -= 1f * Time.deltaTime;
		}
		if (this.lockTime > 0f)
		{
			this.lockTime -= Time.deltaTime;
		}
		else if (this.bDoorLocked & this.requirementMet)
		{
			this.UnlockDoor();
		}
		if (this.openTime <= 0f & this.bDoorOpen & !this.bDoorLocked)
		{
			this.bDoorOpen = false;
			this.inside.sharedMaterial = this.closed;
			this.outside.sharedMaterial = this.closed;
		}
	}

	// Token: 0x0600018B RID: 395 RVA: 0x000098E6 File Offset: 0x00007AE6
	private void OnTriggerStay(Collider other)
	{
		if (!this.bDoorLocked)
		{
			this.bDoorOpen = true;
			this.inside.sharedMaterial = this.open;
			this.outside.sharedMaterial = this.open;
			this.openTime = 2f;
		}
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00009924 File Offset: 0x00007B24
	private void OnTriggerEnter(Collider other)
	{
		if (this.gc.notebooks < 2 & other.tag == "Player")
		{
			this.myAudio.PlayOneShot(this.baldiDoor, 1f);
			return;
		}
		if (!this.bDoorLocked)
		{
			this.myAudio.PlayOneShot(this.doorOpen, 1f);
			if (other.tag == "Player" && this.baldi.isActiveAndEnabled)
			{
				this.baldi.Hear(base.transform.position, 1f);
			}
		}
	}

	// Token: 0x0600018D RID: 397 RVA: 0x000099C4 File Offset: 0x00007BC4
	public void LockDoor(float time)
	{
		this.barrier.enabled = true;
		this.obstacle.SetActive(true);
		this.bDoorLocked = true;
		this.lockTime = time;
		this.inside.sharedMaterial = this.locked;
		this.outside.sharedMaterial = this.locked;
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00009A1C File Offset: 0x00007C1C
	private void UnlockDoor()
	{
		this.barrier.enabled = false;
		this.obstacle.SetActive(false);
		this.bDoorLocked = false;
		this.inside.sharedMaterial = this.closed;
		this.outside.sharedMaterial = this.closed;
	}

	// Token: 0x0400027B RID: 635
	public GameControllerScript gc;

	// Token: 0x0400027C RID: 636
	public BaldiScript baldi;

	// Token: 0x0400027D RID: 637
	public MeshCollider barrier;

	// Token: 0x0400027E RID: 638
	public GameObject obstacle;

	// Token: 0x0400027F RID: 639
	public MeshCollider trigger;

	// Token: 0x04000280 RID: 640
	public MeshRenderer inside;

	// Token: 0x04000281 RID: 641
	public MeshRenderer outside;

	// Token: 0x04000282 RID: 642
	public Material closed;

	// Token: 0x04000283 RID: 643
	public Material open;

	// Token: 0x04000284 RID: 644
	public Material locked;

	// Token: 0x04000285 RID: 645
	public AudioClip doorOpen;

	// Token: 0x04000286 RID: 646
	public AudioClip baldiDoor;

	// Token: 0x04000287 RID: 647
	private float openTime;

	// Token: 0x04000288 RID: 648
	private float lockTime;

	// Token: 0x04000289 RID: 649
	private bool bDoorOpen;

	// Token: 0x0400028A RID: 650
	private bool bDoorLocked;

	// Token: 0x0400028B RID: 651
	private bool requirementMet;

	// Token: 0x0400028C RID: 652
	private AudioSource myAudio;
}
