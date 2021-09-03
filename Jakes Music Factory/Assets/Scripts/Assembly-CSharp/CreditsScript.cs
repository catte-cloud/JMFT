using System;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class CreditsScript : MonoBehaviour
{
	// Token: 0x06000016 RID: 22 RVA: 0x000022B1 File Offset: 0x000004B1
	private void Start()
	{
		this.audioDevice.PlayOneShot(this.music);
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000022C4 File Offset: 0x000004C4
	private void Update()
	{
		base.transform.position -= Vector3.up * -0.9f;
	}

	// Token: 0x04000012 RID: 18
	public AudioSource audioDevice;

	// Token: 0x04000013 RID: 19
	public AudioClip music;
}
