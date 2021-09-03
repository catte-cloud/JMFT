using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class ItemToggle : MonoBehaviour
{
	// Token: 0x06000032 RID: 50 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002706 File Offset: 0x00000906
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			if (this.items.activeSelf)
			{
				this.items.SetActive(false);
				return;
			}
			this.items.SetActive(true);
		}
	}

	// Token: 0x04000029 RID: 41
	public GameObject items;
}
