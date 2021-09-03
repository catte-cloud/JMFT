using System;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class AlarmClockScript : MonoBehaviour
{
	// Token: 0x06000088 RID: 136 RVA: 0x000036A5 File Offset: 0x000018A5
	private void Start()
	{
		this.timeLeft = 30f;
		this.lifeSpan = 35f;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x000036C0 File Offset: 0x000018C0
	private void Update()
	{
		if (this.timeLeft >= 0f)
		{
			this.timeLeft -= Time.deltaTime;
		}
		else if (!this.rang)
		{
			this.Alarm();
		}
		if (this.lifeSpan >= 0f)
		{
			this.lifeSpan -= Time.deltaTime;
			return;
		}
		UnityEngine.Object.Destroy(base.gameObject, 0f);
	}

	// Token: 0x0600008A RID: 138 RVA: 0x0000372C File Offset: 0x0000192C
	private void Alarm()
	{
		this.rang = true;
		this.baldi.Hear(base.transform.position, 10f);
		this.baldi2.Hear(base.transform.position, 10f);
		this.audioDevice.clip = this.ring;
		this.audioDevice.loop = false;
		this.audioDevice.Play();
	}

	// Token: 0x0400009A RID: 154
	public float timeLeft;

	// Token: 0x0400009B RID: 155
	private float lifeSpan;

	// Token: 0x0400009C RID: 156
	private bool rang;

	// Token: 0x0400009D RID: 157
	public BaldiScript baldi;

	// Token: 0x0400009E RID: 158
	public BaldiScript baldi2;

	// Token: 0x0400009F RID: 159
	public AudioClip ring;

	// Token: 0x040000A0 RID: 160
	public AudioSource audioDevice;
}
