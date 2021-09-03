using System;
using UnityEngine;

// Token: 0x0200003D RID: 61
public class FirstPrizeSpriteScript : MonoBehaviour
{
	// Token: 0x060000FE RID: 254 RVA: 0x000054C8 File Offset: 0x000036C8
	private void Start()
	{
		this.sprite = base.GetComponent<SpriteRenderer>();
	}

	// Token: 0x060000FF RID: 255 RVA: 0x000054D8 File Offset: 0x000036D8
	private void Update()
	{
		this.angleF = Mathf.Atan2(this.cam.position.z - this.body.position.z, this.cam.position.x - this.body.position.x) * 57.29578f;
		if (this.angleF < 0f)
		{
			this.angleF += 360f;
		}
		this.debug = this.body.eulerAngles.y;
		this.angleF += this.body.eulerAngles.y;
		this.angle = Mathf.RoundToInt(this.angleF / 22.5f);
		while (this.angle < 0 || this.angle >= 16)
		{
			this.angle += (int)(-16f * Mathf.Sign((float)this.angle));
		}
		this.sprite.sprite = this.sprites[this.angle];
	}

	// Token: 0x04000137 RID: 311
	public float debug;

	// Token: 0x04000138 RID: 312
	public int angle;

	// Token: 0x04000139 RID: 313
	public float angleF;

	// Token: 0x0400013A RID: 314
	private SpriteRenderer sprite;

	// Token: 0x0400013B RID: 315
	public Transform cam;

	// Token: 0x0400013C RID: 316
	public Transform body;

	// Token: 0x0400013D RID: 317
	public Sprite[] sprites = new Sprite[16];
}
