using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000052 RID: 82
public class Script : MonoBehaviour
{
	// Token: 0x06000178 RID: 376 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x06000179 RID: 377 RVA: 0x000094C4 File Offset: 0x000076C4
	private void Update()
	{
		if (!this.audioDevice.isPlaying & this.played)
		{
			SceneManager.LoadScene("Secret");
		}
	}

	// Token: 0x0600017A RID: 378 RVA: 0x000094E7 File Offset: 0x000076E7
	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player" & !this.played)
		{
			this.audioDevice.Play();
			this.played = true;
		}
	}

	// Token: 0x0400026B RID: 619
	public AudioSource audioDevice;

	// Token: 0x0400026C RID: 620
	private bool played;
}
