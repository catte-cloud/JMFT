using System;
using UnityEngine;

// Token: 0x02000024 RID: 36
public class AmbienceScript : MonoBehaviour
{
	// Token: 0x0600008C RID: 140 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x0600008D RID: 141 RVA: 0x000037A0 File Offset: 0x000019A0
	public void PlayAudio()
	{
		int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 49f));
		if (!this.audioDevice.isPlaying & num == 0)
		{
			base.transform.position = this.aiLocation.position;
			int num2 = Mathf.RoundToInt(UnityEngine.Random.Range(0f, (float)(this.sounds.Length - 1)));
			this.audioDevice.PlayOneShot(this.sounds[num2]);
		}
	}

	// Token: 0x040000A1 RID: 161
	public Transform aiLocation;

	// Token: 0x040000A2 RID: 162
	public AudioClip[] sounds;

	// Token: 0x040000A3 RID: 163
	public AudioSource audioDevice;
}
