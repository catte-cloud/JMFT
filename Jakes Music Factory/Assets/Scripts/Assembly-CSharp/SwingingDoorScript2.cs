using System;
using UnityEngine;

// Token: 0x02000057 RID: 87
public class SwingingDoorScript2 : MonoBehaviour
{
	// Token: 0x06000190 RID: 400 RVA: 0x00009A6A File Offset: 0x00007C6A
	private void Start()
	{
		this.myAudio = base.GetComponent<AudioSource>();
		this.bDoorLocked = true;
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00009A80 File Offset: 0x00007C80
	private void Update()
	{
		if (!this.requirementMet & this.gc.notebooks >= 2)
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

	// Token: 0x06000192 RID: 402 RVA: 0x00009B5E File Offset: 0x00007D5E
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

	// Token: 0x06000193 RID: 403 RVA: 0x00009B9C File Offset: 0x00007D9C
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

	// Token: 0x06000194 RID: 404 RVA: 0x00009C3C File Offset: 0x00007E3C
	public void LockDoor(float time)
	{
		this.barrier.enabled = true;
		this.obstacle.SetActive(true);
		this.bDoorLocked = true;
		this.lockTime = time;
		this.inside.sharedMaterial = this.locked;
		this.outside.sharedMaterial = this.locked;
	}

	// Token: 0x06000195 RID: 405 RVA: 0x00009C94 File Offset: 0x00007E94
	private void UnlockDoor()
	{
		this.barrier.enabled = false;
		this.obstacle.SetActive(false);
		this.bDoorLocked = false;
		this.inside.sharedMaterial = this.closed;
		this.outside.sharedMaterial = this.closed;
	}

	// Token: 0x0400028D RID: 653
	public GameControllerScript gc;

	// Token: 0x0400028E RID: 654
	public BaldiScript baldi;

	// Token: 0x0400028F RID: 655
	public MeshCollider barrier;

	// Token: 0x04000290 RID: 656
	public GameObject obstacle;

	// Token: 0x04000291 RID: 657
	public MeshCollider trigger;

	// Token: 0x04000292 RID: 658
	public MeshRenderer inside;

	// Token: 0x04000293 RID: 659
	public MeshRenderer outside;

	// Token: 0x04000294 RID: 660
	public Material closed;

	// Token: 0x04000295 RID: 661
	public Material open;

	// Token: 0x04000296 RID: 662
	public Material locked;

	// Token: 0x04000297 RID: 663
	public AudioClip doorOpen;

	// Token: 0x04000298 RID: 664
	public AudioClip baldiDoor;

	// Token: 0x04000299 RID: 665
	private float openTime;

	// Token: 0x0400029A RID: 666
	private float lockTime;

	// Token: 0x0400029B RID: 667
	private bool bDoorOpen;

	// Token: 0x0400029C RID: 668
	private bool bDoorLocked;

	// Token: 0x0400029D RID: 669
	private bool requirementMet;

	// Token: 0x0400029E RID: 670
	private AudioSource myAudio;
}
