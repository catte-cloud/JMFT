using System;
using UnityEngine;

// Token: 0x02000016 RID: 22
public class MouseAppearingScript : MonoBehaviour
{
	// Token: 0x0600004E RID: 78 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x0600004F RID: 79 RVA: 0x000027D8 File Offset: 0x000009D8
	private void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit) && (raycastHit.collider.tag == "Door" & Vector3.Distance(this.playerTransform.position, raycastHit.transform.position) <= 15f))
		{
			this.MouseCursor.SetActive(true);
			return;
		}
		if (Physics.Raycast(ray, out raycastHit) && (raycastHit.collider.tag == "Item" & Vector3.Distance(this.playerTransform.position, raycastHit.transform.position) <= 10f))
		{
			this.MouseCursor.SetActive(true);
			return;
		}
		if (Physics.Raycast(ray, out raycastHit) && (raycastHit.collider.tag == "Notebook" & Vector3.Distance(this.playerTransform.position, raycastHit.transform.position) <= 10f))
		{
			this.MouseCursor.SetActive(true);
			return;
		}
		if (Physics.Raycast(ray, out raycastHit) && (raycastHit.collider.tag == "OpenableWindow" & Vector3.Distance(this.playerTransform.position, raycastHit.transform.position) <= 10f))
		{
			this.MouseCursor.SetActive(true);
			return;
		}
		this.MouseCursor.SetActive(false);
	}

	// Token: 0x04000037 RID: 55
	public GameObject MouseCursor;

	// Token: 0x04000038 RID: 56
	public Transform playerTransform;
}
