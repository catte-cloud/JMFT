using System;
using UnityEngine;

// Token: 0x0200002E RID: 46
public class ClickableTest : MonoBehaviour
{
	// Token: 0x060000BE RID: 190 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x060000BF RID: 191 RVA: 0x000045DC File Offset: 0x000027DC
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit) && raycastHit.transform.name == "MathNotebook")
		{
			base.gameObject.SetActive(false);
		}
	}
}
