using System;
using UnityEngine;

// Token: 0x02000058 RID: 88
public class TapePlayerScript : MonoBehaviour
{
	// Token: 0x06000197 RID: 407 RVA: 0x00009CE2 File Offset: 0x00007EE2
	private void Start()
	{
		this.audioDevice = base.GetComponent<AudioSource>();
	}

	// Token: 0x06000198 RID: 408 RVA: 0x00009CF0 File Offset: 0x00007EF0
	private void Update()
	{
		if (this.audioDevice.isPlaying & Time.timeScale == 0f)
		{
			this.audioDevice.Pause();
			return;
		}
		if (Time.timeScale > 0f & this.baldi.antiHearingTime > 0f)
		{
			this.audioDevice.UnPause();
		}
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00009D4F File Offset: 0x00007F4F
	public void Play()
	{
		this.sprite.sprite = this.closedSprite;
		this.audioDevice.Play();
		this.baldi.ActivateAntiHearing(30f);
	}

	// Token: 0x0400029F RID: 671
	public Sprite closedSprite;

	// Token: 0x040002A0 RID: 672
	public SpriteRenderer sprite;

	// Token: 0x040002A1 RID: 673
	public BaldiScript baldi;

	// Token: 0x040002A2 RID: 674
	private AudioSource audioDevice;
}
