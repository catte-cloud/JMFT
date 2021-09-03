using System;
using UnityEngine;

// Token: 0x02000015 RID: 21
public class MiniMapTog : MonoBehaviour
{
	// Token: 0x0600004B RID: 75 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x0600004C RID: 76 RVA: 0x000027A4 File Offset: 0x000009A4
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (this.minimap.activeSelf)
			{
				this.minimap.SetActive(false);
				return;
			}
			this.minimap.SetActive(true);
		}
	}

	// Token: 0x04000036 RID: 54
	public GameObject minimap;
}
