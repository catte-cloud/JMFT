using System;
using UnityEngine;

// Token: 0x02000025 RID: 37
public class AudioQueueScript : MonoBehaviour
{
	// Token: 0x0600008F RID: 143 RVA: 0x0000381B File Offset: 0x00001A1B
	private void Start()
	{
		this.audioDevice = base.GetComponent<AudioSource>();
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00003829 File Offset: 0x00001A29
	private void Update()
	{
		if (!this.audioDevice.isPlaying && this.audioInQueue > 0)
		{
			this.PlayQueue();
		}
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00003847 File Offset: 0x00001A47
	public void QueueAudio(AudioClip sound)
	{
		this.audioQueue[this.audioInQueue] = sound;
		this.audioInQueue++;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00003865 File Offset: 0x00001A65
	private void PlayQueue()
	{
		this.audioDevice.PlayOneShot(this.audioQueue[0]);
		this.UnqueueAudio();
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00003880 File Offset: 0x00001A80
	private void UnqueueAudio()
	{
		for (int i = 1; i < this.audioInQueue; i++)
		{
			this.audioQueue[i - 1] = this.audioQueue[i];
		}
		this.audioInQueue--;
	}

	// Token: 0x06000094 RID: 148 RVA: 0x000038BE File Offset: 0x00001ABE
	public void ClearAudioQueue()
	{
		this.audioInQueue = 0;
	}

	// Token: 0x040000A4 RID: 164
	private AudioSource audioDevice;

	// Token: 0x040000A5 RID: 165
	private int audioInQueue;

	// Token: 0x040000A6 RID: 166
	private AudioClip[] audioQueue = new AudioClip[100];
}
