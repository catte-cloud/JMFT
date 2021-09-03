using System;
using UnityEngine;

// Token: 0x02000036 RID: 54
public class EndlessNotebookScript : MonoBehaviour
{
	// Token: 0x060000E3 RID: 227 RVA: 0x00004D51 File Offset: 0x00002F51
	private void Start()
	{
		this.gc = GameObject.Find("Game Controller").GetComponent<GameControllerScript>();
		this.player = GameObject.Find("Player").GetComponent<Transform>();
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00004D80 File Offset: 0x00002F80
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit) && (raycastHit.transform.tag == "Notebook" & Vector3.Distance(this.player.position, base.transform.position) < this.openingDistance))
		{
			base.gameObject.SetActive(false);
			this.gc.CollectNotebook();
			this.learningGame.SetActive(true);
		}
	}

	// Token: 0x04000111 RID: 273
	public float openingDistance;

	// Token: 0x04000112 RID: 274
	public GameControllerScript gc;

	// Token: 0x04000113 RID: 275
	public Transform player;

	// Token: 0x04000114 RID: 276
	public GameObject learningGame;
}
