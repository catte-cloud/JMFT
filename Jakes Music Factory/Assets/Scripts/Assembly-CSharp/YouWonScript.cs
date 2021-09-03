using System;
using UnityEngine;

// Token: 0x0200005B RID: 91
public class YouWonScript : MonoBehaviour
{
	// Token: 0x060001A4 RID: 420 RVA: 0x0000A02E File Offset: 0x0000822E
	private void Start()
	{
		this.delay = 10f;
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x0000A03B File Offset: 0x0000823B
	private void Update()
	{
		this.delay -= Time.deltaTime;
		if (this.delay <= 0f)
		{
			Application.Quit();
		}
	}

	// Token: 0x040002B3 RID: 691
	private float delay;
}
