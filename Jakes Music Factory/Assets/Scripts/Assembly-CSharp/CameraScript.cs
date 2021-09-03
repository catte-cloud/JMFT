using System;
using UnityEngine;

// Token: 0x0200002D RID: 45
public class CameraScript : MonoBehaviour
{
	// Token: 0x060000BA RID: 186 RVA: 0x0000434A File Offset: 0x0000254A
	private void Start()
	{
		this.offset = base.transform.position - this.player.transform.position;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00004374 File Offset: 0x00002574
	private void Update()
	{
		if (this.ps.jumpRope)
		{
			this.velocity -= this.gravity * Time.deltaTime;
			this.jumpHeight += this.velocity * Time.deltaTime;
			if (this.jumpHeight <= 0f)
			{
				this.jumpHeight = 0f;
				if (Input.GetKeyDown(KeyCode.Space))
				{
					this.velocity = this.initVelocity;
				}
			}
			this.jumpHeightV3 = new Vector3(0f, this.jumpHeight, 0f);
			return;
		}
		if (Input.GetButton("Look Behind"))
		{
			this.lookBehind = 180;
			return;
		}
		this.lookBehind = 0;
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00004428 File Offset: 0x00002628
	private void LateUpdate()
	{
		base.transform.position = this.player.transform.position + this.offset;
		if (!this.ps.gameOver & !this.ps.jumpRope)
		{
			base.transform.position = this.player.transform.position + this.offset;
			base.transform.rotation = this.player.transform.rotation * Quaternion.Euler(0f, (float)this.lookBehind, 0f);
			return;
		}
		if (this.ps.gameOver)
		{
			base.transform.position = this.baldi.transform.position + this.baldi.transform.forward * 2f + new Vector3(0f, 0f, 0f);
			base.transform.LookAt(new Vector3(this.baldi.position.x, this.baldi.position.y + 5f, this.baldi.position.z));
			return;
		}
		if (this.ps.jumpRope)
		{
			base.transform.position = this.player.transform.position + this.offset + this.jumpHeightV3;
			base.transform.rotation = this.player.transform.rotation;
		}
	}

	// Token: 0x040000DC RID: 220
	public GameObject player;

	// Token: 0x040000DD RID: 221
	public PlayerScript ps;

	// Token: 0x040000DE RID: 222
	public Transform baldi;

	// Token: 0x040000DF RID: 223
	public float initVelocity;

	// Token: 0x040000E0 RID: 224
	public float velocity;

	// Token: 0x040000E1 RID: 225
	public float gravity;

	// Token: 0x040000E2 RID: 226
	private int lookBehind;

	// Token: 0x040000E3 RID: 227
	private Vector3 offset;

	// Token: 0x040000E4 RID: 228
	public float jumpHeight;

	// Token: 0x040000E5 RID: 229
	private Vector3 jumpHeightV3;
}
