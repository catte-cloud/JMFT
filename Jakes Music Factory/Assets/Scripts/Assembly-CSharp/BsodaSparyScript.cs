using System;
using UnityEngine;

// Token: 0x0200002B RID: 43
public class BsodaSparyScript : MonoBehaviour
{
	// Token: 0x060000B0 RID: 176 RVA: 0x00003E8C File Offset: 0x0000208C
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
		this.rb.velocity = base.transform.forward * this.speed;
		this.lifeSpan = 30f;
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00003EC8 File Offset: 0x000020C8
	private void Update()
	{
		this.rb.velocity = base.transform.forward * this.speed;
		this.lifeSpan -= Time.deltaTime;
		if (this.lifeSpan < 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject, 0f);
		}
	}

	// Token: 0x040000CB RID: 203
	public float speed;

	// Token: 0x040000CC RID: 204
	private float lifeSpan;

	// Token: 0x040000CD RID: 205
	private Rigidbody rb;
}
