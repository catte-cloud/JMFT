using System;
using UnityEngine;

// Token: 0x02000048 RID: 72
public class PickupScript : MonoBehaviour
{
    // Token: 0x06000141 RID: 321 RVA: 0x0000205E File Offset: 0x0000025E
    private void Start()
    {
    }

    // Token: 0x06000142 RID: 322 RVA: 0x00007B7C File Offset: 0x00005D7C
    private void Update()
    {
        RaycastHit raycastHit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit))
        {
            if (raycastHit.transform.name == "Pickup_EnergyFlavoredZestyBar" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(1);
                return;
            }
            if (raycastHit.transform.name == "Pickup_YellowDoorLock" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(2);
                return;
            }
            if (raycastHit.transform.name == "Pickup_Key" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(3);
                return;
            }
            if (raycastHit.transform.name == "Pickup_BSODA" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(4);
                return;
            }
            if (raycastHit.transform.name == "Pickup_Quarter" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(5);
                gc.GetComponent<TicketsScript>().AddTickets(5);
                return;
            }
            if (raycastHit.transform.name == "Pickup_Tape" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(6);
                return;
            }
            if (raycastHit.transform.name == "Pickup_AlarmClock" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(7);
                return;
            }
            if (raycastHit.transform.name == "Pickup_WD-3D" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(8);
                return;
            }
            if (raycastHit.transform.name == "Pickup_SafetyScissors" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(9);
                return;
            }
            if (raycastHit.transform.name == "Pickup_VanillaMuffin" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(10);
                return;
            }
            if (raycastHit.transform.name == "Pickup_Zsoda" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(11);
                return;
            }
            if (raycastHit.transform.name == "Pickup_Anti-Alarm" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(12);
                return;
            }
            if (raycastHit.transform.name == "Pickup_EventButton" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(13);
                return;
            }
            if (raycastHit.transform.name == "Pickup_Whistle" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(14);
                return;
            }
            if (raycastHit.transform.name == "Pickup_WindowKey" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(15);
                return;
            }
            if (raycastHit.transform.name == "Pickup_Gift" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
            {
                raycastHit.transform.gameObject.SetActive(false);
                this.gc.CollectItem(16);
            }
        }
    }

    // Token: 0x300999F9 RID: 499
    public GameControllerScript gc;

    // Token: 0x040001F4 RID: 500
    public Transform player;
}
