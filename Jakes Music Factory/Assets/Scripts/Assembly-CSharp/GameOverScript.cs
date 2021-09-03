using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x0200003F RID: 63
public class GameOverScript : MonoBehaviour
{
	// Token: 0x0600011A RID: 282 RVA: 0x00006F14 File Offset: 0x00005114
	private void Start()
	{
		this.image = base.GetComponent<Image>();
		this.audioDevice = base.GetComponent<AudioSource>();
		this.delay = 5f;
		this.chance = UnityEngine.Random.Range(1f, 99f);
		if (this.chance < 98f)
		{
			int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 4f));
			this.image.sprite = this.images[num];
			return;
		}
		this.image.sprite = this.rare;
	}

	// Token: 0x0600011B RID: 283 RVA: 0x00006FA0 File Offset: 0x000051A0
	private void Update()
	{
		this.delay -= 1f * Time.deltaTime;
		if (this.delay <= 0f)
		{
			if (this.chance < 98f)
			{
				Application.Quit();
				return;
			}
			SceneManager.LoadScene("daisy");
		}
	}

	// Token: 0x040001A8 RID: 424
	private Image image;

	// Token: 0x040001A9 RID: 425
	private float delay;

	// Token: 0x040001AA RID: 426
	public Sprite[] images = new Sprite[5];

	// Token: 0x040001AB RID: 427
	public Sprite rare;

	// Token: 0x040001AC RID: 428
	private float chance;

	// Token: 0x040001AD RID: 429
	private AudioSource audioDevice;
}
