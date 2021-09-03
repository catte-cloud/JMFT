using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x0200003E RID: 62
public class GameControllerScript : MonoBehaviour
{
    // Token: 0x06000101 RID: 257 RVA: 0x00005604 File Offset: 0x00003804
    public GameControllerScript()
    {
        int[] array = new int[3];
        array[0] = -80;
        array[1] = -40;
        this.itemSelectOffset = array;
    }

    // Token: 0x06000102 RID: 258 RVA: 0x00005700 File Offset: 0x00003900
    private void Start()
    {
        this.audioDevice = base.GetComponent<AudioSource>();
        this.mode = PlayerPrefs.GetString("CurrentMode");
        if (this.mode == "endless")
        {
            this.baldiScrpt.endless = true;
            this.baldiScript.endless = true;
        }
        this.schoolMusic.Play();
        this.LockMouse();
        this.UpdateNotebookCount();
        this.itemSelected = 0;
        this.gameOverDelay = 0.5f;
    }

    // Token: 0x06000103 RID: 259 RVA: 0x0000577C File Offset: 0x0000397C
    private void Update()
    {
        if (!this.learningActive)
        {
            if (Input.GetButtonDown("Pause"))
            {
                if (!this.gamePaused)
                {
                    this.PauseGame();
                }
                else
                {
                    this.UnpauseGame();
                }
            }
            if (Input.GetKeyDown(KeyCode.Y) & this.gamePaused)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else if (Input.GetKeyDown(KeyCode.N) & this.gamePaused)
            {
                this.UnpauseGame();
            }
            if (!this.gamePaused & Time.timeScale != 1f)
            {
                Time.timeScale = 1f;
            }
            if (Input.GetMouseButtonDown(1))
            {
                this.UseItem();
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                this.DecreaseItemSelection();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                this.IncreaseItemSelection();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                this.itemSelected = 0;
                this.UpdateItemSelection();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                this.itemSelected = 1;
                this.UpdateItemSelection();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                this.itemSelected = 2;
                this.UpdateItemSelection();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) & Time.timeScale != 0f)
            {
                this.itemSelected = 3;
                this.UpdateItemSelection();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) & Time.timeScale != 0f)
            {
                this.itemSelected = 4;
                this.UpdateItemSelection();
            }
        }
        else if (Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
        }
        if (this.player.stamina < 0f & !this.warning.activeSelf)
        {
            this.warning.SetActive(true);
        }
        else if (this.player.stamina > 0f & this.warning.activeSelf)
        {
            this.warning.SetActive(false);
        }
        if (this.player.gameOver)
        {
            Time.timeScale = 0f;
            this.gameOverDelay -= Time.unscaledDeltaTime;
            this.audioDevice.PlayOneShot(this.aud_buzz);
            if (this.gameOverDelay <= 0f)
            {
                if (this.mode == "endless")
                {
                    if (this.notebooks > PlayerPrefs.GetInt("HighBooks"))
                    {
                        PlayerPrefs.SetInt("HighBooks", this.notebooks);
                        PlayerPrefs.SetInt("HighTime", Mathf.FloorToInt(this.time));
                        this.highScoreText.SetActive(true);
                    }
                    else if (this.notebooks == PlayerPrefs.GetInt("HighBooks") & Mathf.FloorToInt(this.time) > PlayerPrefs.GetInt("HighTime"))
                    {
                        PlayerPrefs.SetInt("HighTime", Mathf.FloorToInt(this.time));
                        this.highScoreText.SetActive(true);
                    }
                    PlayerPrefs.SetInt("CurrentBooks", this.notebooks);
                    PlayerPrefs.SetInt("CurrentTime", Mathf.FloorToInt(this.time));
                }
                Time.timeScale = 1f;
                SceneManager.LoadScene("GameOver");
            }
        }
        if (this.finaleMode && !this.audioDevice.isPlaying && this.exitsReached == 3)
        {
            this.audioDevice.clip = this.aud_MachineLoop;
            this.audioDevice.loop = true;
            this.audioDevice.Play();
        }
        this.time += Time.deltaTime;
    }

    // Token: 0x06000104 RID: 260 RVA: 0x00005AE0 File Offset: 0x00003CE0
    private void UpdateNotebookCount()
    {
        if (this.mode == "story")
        {
            this.notebookCount.text = this.notebooks.ToString() + "/7 Instruments";
        }
        if (this.mode == "double")
        {
            this.notebookCount.text = this.notebooks.ToString() + "/7 Instruments";
            this.baldiTutor2.SetActive(true);
        }
        if (this.mode == "pie")
        {
            this.notebookCount.text = this.notebooks.ToString() + "/10 Instruments";
            this.baldiTutor.SetActive(false);
            this.RandomEventScript.enabled = false;
        }
        else
        {
            this.notebookCount.text = this.notebooks.ToString() + "/7 Instruments";
        }
        if (this.notebooks == 7 & this.mode == "story")
        {
            this.ActivateFinaleMode();
        }
        if (this.notebooks == 7 & this.mode == "double")
        {
            this.ActivateFinaleMode();
        }
        if (this.notebooks == 7 & this.mode == "endless")
        {
            this.ActivateFinaleMode();
        }
        if (this.notebooks == 10 & this.mode == "pie")
        {
            this.ActivateFinaleMode();
        }
    }

    // Token: 0x06000105 RID: 261 RVA: 0x00005C52 File Offset: 0x00003E52
    public void CollectNotebook()
    {
        this.notebooks++;
        this.UpdateNotebookCount();
        this.time = 0f;
    }

    // Token: 0x06000106 RID: 262 RVA: 0x00005C73 File Offset: 0x00003E73
    public void LockMouse()
    {
        if (!this.learningActive)
        {
            this.cursorController.LockCursor();
            this.mouseLocked = true;
            this.reticle.SetActive(true);
        }
    }

    // Token: 0x06000107 RID: 263 RVA: 0x00005C9B File Offset: 0x00003E9B
    public void UnlockMouse()
    {
        this.cursorController.UnlockCursor();
        this.mouseLocked = false;
        this.reticle.SetActive(false);
    }

    // Token: 0x06000108 RID: 264 RVA: 0x00005CBC File Offset: 0x00003EBC
    private void PauseGame()
    {
        Time.timeScale = 0f;
        this.gamePaused = true;
        this.pauseText.SetActive(true);
        this.baldiNod.SetActive(true);
        this.baldiShake.SetActive(true);
        this.toggleoffbutton.SetActive(true);
        this.toggleonbutton.SetActive(true);
        this.UnlockMouse();
    }

    // Token: 0x06000109 RID: 265 RVA: 0x00005D1C File Offset: 0x00003F1C
    private void UnpauseGame()
    {
        Time.timeScale = 1f;
        this.gamePaused = false;
        this.pauseText.SetActive(false);
        this.baldiNod.SetActive(false);
        this.baldiShake.SetActive(false);
        this.toggleoffbutton.SetActive(false);
        this.toggleonbutton.SetActive(false);
        this.LockMouse();
    }

    // Token: 0x0600010A RID: 266 RVA: 0x00005D7C File Offset: 0x00003F7C
    public void ActivateSpoopMode()
    {
        if (this.mode == "double")
        {
            this.spoopMode = true;
            this.entrance_0.Lower();
            this.entrance_1.Lower();
            this.entrance_2.Lower();
            this.entrance_3.Lower();
            this.baldiTutor.SetActive(false);
            this.baldi.SetActive(true);
            this.principal.SetActive(true);
            this.yeet.SetActive(true);
            this.glitchy.SetActive(true);
            this.crafters.SetActive(true);
            this.playtime.SetActive(true);
            this.gottaSweep.SetActive(false);
            this.bully.SetActive(true);
            this.firstPrize.SetActive(true);
            this.audioDevice.PlayOneShot(this.aud_Hang);
            this.learnMusic.Stop();
            this.schoolMusic.Stop();
            this.madglitchy.SetActive(false);
            this.baldi2.SetActive(true);
            this.baldiTutor2.SetActive(false);
        }
        if (this.mode == "story")
        {
            this.spoopMode = true;
            this.entrance_0.Lower();
            this.entrance_1.Lower();
            this.entrance_2.Lower();
            this.entrance_3.Lower();
            this.baldiTutor.SetActive(false);
            this.baldi.SetActive(true);
            this.principal.SetActive(true);
            this.yeet.SetActive(true);
            this.glitchy.SetActive(true);
            this.crafters.SetActive(true);
            this.playtime.SetActive(true);
            this.gottaSweep.SetActive(false);
            this.bully.SetActive(true);
            this.firstPrize.SetActive(true);
            this.audioDevice.PlayOneShot(this.aud_Hang);
            this.learnMusic.Stop();
            this.schoolMusic.Stop();
            this.madglitchy.SetActive(false);
            this.baldi2.SetActive(false);
            this.baldiTutor2.SetActive(false);
            this.nurse.SetActive(true);
            this.unnameable.SetActive(true);
        }
        if (this.mode == "pie")
        {
            this.spoopMode = true;
            this.entrance_0.Lower();
            this.entrance_1.Lower();
            this.entrance_2.Lower();
            this.entrance_3.Lower();
            this.baldiTutor.SetActive(false);
            this.baldi.SetActive(false);
            this.principal.SetActive(false);
            this.yeet.SetActive(false);
            this.glitchy.SetActive(false);
            this.crafters.SetActive(false);
            this.playtime.SetActive(false);
            this.gottaSweep.SetActive(false);
            this.bully.SetActive(true);
            this.firstPrize.SetActive(false);
            this.audioDevice.PlayOneShot(this.aud_Hang);
            this.learnMusic.Stop();
            this.schoolMusic.Stop();
            this.madglitchy.SetActive(false);
            this.baldi2.SetActive(false);
            this.baldiTutor2.SetActive(false);
            this.PranksterEvil.SetActive(true);
            this.PranksterEvil1.SetActive(true);
            this.PranksterEvil2.SetActive(true);
            this.PranksterEvil3.SetActive(true);
            this.PranksterEvil4.SetActive(true);
            this.PranksterEvil5.SetActive(true);
            this.ExtraNotebook8.SetActive(true);
            this.EXN9.SetActive(true);
            this.EXN10.SetActive(true);
        }
    }

    // Token: 0x0600010B RID: 267 RVA: 0x0000612E File Offset: 0x0000432E
    private void ActivateFinaleMode()
    {
        base.GetComponentInParent<TicketsScript>().AddTickets(50);
        this.finaleMode = true;
        this.entrance_0.Raise();
        this.entrance_1.Raise();
        this.entrance_2.Raise();
        this.entrance_3.Raise();
    }

    // Token: 0x0600010C RID: 268 RVA: 0x00006163 File Offset: 0x00004363
    public void GetAngry(float value)
    {
        if (!this.spoopMode)
        {
            this.ActivateSpoopMode();
        }
        this.baldiScrpt.GetAngry(value);
    }

    // Token: 0x0600010D RID: 269 RVA: 0x00006180 File Offset: 0x00004380
    public void ActivateLearningGame()
    {
        this.learningActive = true;
        this.UnpauseGame();
        this.UnlockMouse();
        this.tutorBaldi.Stop();
        this.tutorBaldi2.Stop();
        if (!this.spoopMode)
        {
            this.schoolMusic.Stop();
            this.learnMusic.Play();
        }
    }

    // Token: 0x0600010E RID: 270 RVA: 0x000061D4 File Offset: 0x000043D4
    public void DeactivateLearningGame(GameObject subject)
    {
        this.learningActive = false;
        UnityEngine.Object.Destroy(subject);
        this.LockMouse();
        if (this.player.stamina < 100f)
        {
            this.player.stamina = 100f;
        }
        if (!this.spoopMode)
        {
            this.schoolMusic.Play();
            this.learnMusic.Stop();
        }
        if (this.notebooks == 1 & !this.spoopMode)
        {
            this.quarter.SetActive(true);
            this.tutorBaldi.PlayOneShot(this.aud_Prize);
            return;
        }
        if (this.notebooks == 7 & this.mode == "story")
        {
            this.audioDevice.PlayOneShot(this.aud_AllNotebooks, 0.8f);
            base.GetComponentInParent<TicketsScript>().AddTickets(50);
        }
    }

    // Token: 0x0600010F RID: 271 RVA: 0x0000629C File Offset: 0x0000449C
    private void IncreaseItemSelection()
    {
        this.itemSelected++;
        if (this.itemSelected > 2)
        {
            this.itemSelected = 0;
        }
        this.itemSelect.anchoredPosition = new Vector3((float)this.itemSelectOffset[this.itemSelected], 0f, 0f);
        this.UpdateItemName();
    }

    // Token: 0x06000110 RID: 272 RVA: 0x000062FC File Offset: 0x000044FC
    private void DecreaseItemSelection()
    {
        this.itemSelected--;
        if (this.itemSelected < 0)
        {
            this.itemSelected = 2;
        }
        this.itemSelect.anchoredPosition = new Vector3((float)this.itemSelectOffset[this.itemSelected], 0f, 0f);
        this.UpdateItemName();
    }

    // Token: 0x06000111 RID: 273 RVA: 0x0000635A File Offset: 0x0000455A
    private void UpdateItemSelection()
    {
        this.itemSelect.anchoredPosition = new Vector3((float)this.itemSelectOffset[this.itemSelected], 0f, 0f);
        this.UpdateItemName();
    }

    // Token: 0x06000112 RID: 274 RVA: 0x00006390 File Offset: 0x00004590
    public void CollectItem(int item_ID)
    {
        
        if (this.item[0] == 0)
        {
            this.item[0] = item_ID;
            this.itemSlot[0].texture = this.itemTextures[item_ID];
        }
        else if (this.item[1] == 0)
        {
            this.item[1] = item_ID;
            this.itemSlot[1].texture = this.itemTextures[item_ID];
        }
        else if (this.item[2] == 0)
        {
            this.item[2] = item_ID;
            this.itemSlot[2].texture = this.itemTextures[item_ID];
        }
        else
        {
            this.item[this.itemSelected] = item_ID;
            this.itemSlot[this.itemSelected].texture = this.itemTextures[item_ID];
        }
        this.UpdateItemName();
    }

    // Token: 0x06000113 RID: 275 RVA: 0x0000644C File Offset: 0x0000464C
    private void UseItem()
    {
        if (this.item[this.itemSelected] != 0)
        {
            if (this.item[this.itemSelected] == 1)
            {
                this.player.stamina = this.player.maxStamina * 2f;
                this.audioDevice.PlayOneShot(this.aud_Eat);
                this.ResetItem();
                return;
            }
            if (this.item[this.itemSelected] == 2)
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit) && (raycastHit.collider.tag == "SwingingDoor" & Vector3.Distance(this.playerTransform.position, raycastHit.transform.position) <= 10f))
                {
                    raycastHit.collider.gameObject.GetComponent<SwingingDoorScript>().LockDoor(15f);
                    this.ResetItem();
                    return;
                }
            }
            else if (this.item[this.itemSelected] == 3)
            {
                RaycastHit raycastHit2;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit2) && (raycastHit2.collider.tag == "Door" & Vector3.Distance(this.playerTransform.position, raycastHit2.transform.position) <= 10f))
                {
                    raycastHit2.collider.gameObject.GetComponent<DoorScript>().UnlockDoor();
                    raycastHit2.collider.gameObject.GetComponent<DoorScript>().OpenDoor();
                    this.ResetItem();
                    return;
                }
            }
            else
            {
                if (this.item[this.itemSelected] == 4)
                {
                    UnityEngine.Object.Instantiate<GameObject>(this.bsodaSpray, this.playerTransform.position, this.cameraTransform.rotation);
                    this.ResetItem();
                    this.player.ResetGuilt("drink", 1f);
                    this.audioDevice.PlayOneShot(this.aud_Soda);
                    return;
                }
                if (this.item[this.itemSelected] == 5)
                {
                    RaycastHit raycastHit3;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit3))
                    {
                        if (raycastHit3.collider.name == "BSODAMachine" & Vector3.Distance(this.playerTransform.position, raycastHit3.transform.position) <= 10f)
                        {
                            this.ResetItem();
                            this.CollectItem(4);
                            return;
                        }
                        if (raycastHit3.collider.name == "ZestyMachine" & Vector3.Distance(this.playerTransform.position, raycastHit3.transform.position) <= 10f)
                        {
                            this.ResetItem();
                            this.CollectItem(1);
                            return;
                        }
                        if (raycastHit3.collider.name == "PayPhone" & Vector3.Distance(this.playerTransform.position, raycastHit3.transform.position) <= 10f)
                        {
                            raycastHit3.collider.gameObject.GetComponent<TapePlayerScript>().Play();
                            this.ResetItem();
                            return;
                        }
                    }
                }
                else if (this.item[this.itemSelected] == 6)
                {
                    RaycastHit raycastHit4;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit4) && (raycastHit4.collider.name == "TapePlayer" & Vector3.Distance(this.playerTransform.position, raycastHit4.transform.position) <= 10f))
                    {
                        raycastHit4.collider.gameObject.GetComponent<TapePlayerScript>().Play();
                        this.ResetItem();
                        this.ResetItem();
                        this.ResetItem();
                        return;
                    }
                }
                else
                {
                    if (this.item[this.itemSelected] == 7)
                    {
                        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.alarmClock, this.playerTransform.position, this.cameraTransform.rotation);
                        gameObject.GetComponent<AlarmClockScript>().baldi = this.baldiScrpt;
                        gameObject.GetComponent<AlarmClockScript>().baldi2 = this.baldiScript;
                        this.ResetItem();
                        return;
                    }
                    if (this.item[this.itemSelected] == 8)
                    {
                        RaycastHit raycastHit5;
                        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit5) && (raycastHit5.collider.tag == "Door" & Vector3.Distance(this.playerTransform.position, raycastHit5.transform.position) <= 10f))
                        {
                            raycastHit5.collider.gameObject.GetComponent<DoorScript>().SilenceDoor();
                            this.ResetItem();
                            this.audioDevice.PlayOneShot(this.aud_Spray);
                            return;
                        }
                    }
                    else if (this.item[this.itemSelected] == 9)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (this.player.jumpRope)
                        {
                            this.player.DeactivateJumpRope();
                            this.playtimeScript.Disappoint();
                            this.ResetItem();
                            return;
                        }
                        RaycastHit raycastHit6;
                        if (Physics.Raycast(ray, out raycastHit6) && raycastHit6.collider.name == "1st Prize")
                        {
                            this.firstPrizeScript.GoCrazy();
                            this.ResetItem();
                            return;
                        }
                    }
                    else
                    {
                        if (this.item[this.itemSelected] == 10)
                        {
                            this.player.stamina = this.player.maxStamina + 1f;
                            this.audioDevice.PlayOneShot(this.aud_Eat);
                            this.ResetItem();
                            return;
                        }
                        if (this.item[this.itemSelected] == 11)
                        {
                            UnityEngine.Object.Instantiate<GameObject>(this.osodaSpray, this.playerTransform.position, this.cameraTransform.rotation);
                            this.ResetItem();
                            this.player.ResetGuilt("drink", 1f);
                            this.audioDevice.PlayOneShot(this.aud_Soda);
                            return;
                        }
                        if (this.item[this.itemSelected] == 12)
                        {
                            this.player.ResetGuilt("drink", 0f);
                            this.player.ResetGuilt("running", 0f);
                            this.jazz.agent.Warp(new Vector3(-2763f, 4f, 113f));
                            this.glitch.agent.Warp(new Vector3(-2763f, 4f, 113f));
                            this.audioDevice.PlayOneShot(this.aud_Horn);
                            this.ResetItem();
                            this.jazz.angry = false;
                            this.jake.TargetPlayer();
                            return;
                        }
                        if (this.item[this.itemSelected] == 13)
                        {
                            this.baldi.SetActive(false);
                            this.audioDevice.PlayOneShot(this.aud_Switch, 0.8f);
                            this.ResetItem();
                            return;
                        }
                        if (this.item[this.itemSelected] == 14)
                        {
                            this.jazz.TargetPlayer();
                            this.audioDevice.PlayOneShot(this.dontworry, 0.8f);
                            this.ResetItem();
                            return;
                        }
                        if (this.item[this.itemSelected] == 15)
                        {
                            RaycastHit raycastHit7;
                            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit7) && (raycastHit7.collider.tag == "OpenableWindow" & Vector3.Distance(this.playerTransform.position, raycastHit7.transform.position) <= 10f))
                            {
                                WindowScript component = raycastHit7.collider.GetComponent<WindowScript>();
                                component.windowcollider.enabled = false;
                                component.windowcollider2.enabled = false;
                                component.inside.sharedMaterial = component.windowopen;
                                component.outside.sharedMaterial = component.windowopen;
                                this.player.ResetGuilt("Annoyance", 1f);
                                this.ResetItem();
                                return;
                            }
                        }
                        else if (this.item[this.itemSelected] == 16)
                        {
                            this.itemchance = UnityEngine.Random.Range(1, 12 - 1);
                            this.CollectItem(itemchance);
                        }
                    }
                }
            }
        }
    }

    // Token: 0x06000114 RID: 276 RVA: 0x00006D19 File Offset: 0x00004F19
    public void ResetItem()
    {
        this.item[this.itemSelected] = 0;
        this.itemSlot[this.itemSelected].texture = this.itemTextures[0];
        this.UpdateItemName();
    }

    // Token: 0x06000115 RID: 277 RVA: 0x00006D4C File Offset: 0x00004F4C
    public void StealItems()
    {
        this.item[this.itemSelected] = 0;
        this.item[this.itemSelected] = 1;
        this.item[this.itemSelected] = 2;
        this.itemSlot[this.itemSelected].texture = this.itemTextures[0];
        this.itemSlot[this.itemSelected].texture = this.itemTextures[1];
        this.itemSlot[this.itemSelected].texture = this.itemTextures[2];
        this.UpdateItemName();
    }

    // Token: 0x06000116 RID: 278 RVA: 0x00006DD7 File Offset: 0x00004FD7
    public void LoseItem(int id)
    {
        this.item[id] = 0;
        this.itemSlot[id].texture = this.itemTextures[0];
        this.UpdateItemName();
    }

    // Token: 0x06000117 RID: 279 RVA: 0x00006DFD File Offset: 0x00004FFD
    private void UpdateItemName()
    {
        this.itemText.text = this.itemNames[this.item[this.itemSelected]];
    }

    // Token: 0x06000118 RID: 280 RVA: 0x00006E20 File Offset: 0x00005020
    public void ExitReached()
    {
        base.GetComponentInParent<TicketsScript>().AddTickets(20);
        this.exitsReached++;
        if (this.exitsReached == 1)
        {
            RenderSettings.ambientLight = Color.black;
            RenderSettings.fog = true;
            this.audioDevice.PlayOneShot(this.aud_Switch, 0.8f);
            this.audioDevice.clip = this.aud_MachineQuiet;
            this.audioDevice.loop = true;
            this.audioDevice.Play();

        }
        if (this.exitsReached == 2)
        {
            this.audioDevice.volume = 0.8f;
            this.audioDevice.clip = this.aud_MachineStart;
            this.audioDevice.loop = true;
            this.audioDevice.Play();
        }
        if (this.exitsReached == 3)
        {
            this.audioDevice.clip = this.aud_MachineRev;
            this.audioDevice.loop = false;
            this.audioDevice.Play();
        }
    }

    // Token: 0x06000119 RID: 281 RVA: 0x00006F04 File Offset: 0x00005104
    public void DespawnCrafters()
    {
        this.crafters.SetActive(false);
    }

    // Token: 0x0400013E RID: 318
    public CursorControllerScript cursorController;

    // Token: 0x0400013F RID: 319
    public PlayerScript player;

    // Token: 0x04000140 RID: 320
    public Transform playerTransform;

    // Token: 0x04000141 RID: 321
    public Transform cameraTransform;

    // Token: 0x04000142 RID: 322
    public EntranceScript entrance_0;

    // Token: 0x04000143 RID: 323
    public EntranceScript entrance_1;

    // Token: 0x04000144 RID: 324
    public EntranceScript entrance_2;

    // Token: 0x04000145 RID: 325
    public EntranceScript entrance_3;

    // Token: 0x04000146 RID: 326
    public GameObject baldiTutor;

    // Token: 0x04000147 RID: 327
    public GameObject baldiTutor2;

    // Token: 0x04000148 RID: 328
    public GameObject baldi;

    // Token: 0x04000149 RID: 329
    public GameObject baldi2;

    // Token: 0x0400014A RID: 330
    public BaldiScript baldiScrpt;

    // Token: 0x0400014B RID: 331
    public BaldiScript baldiScript;

    // Token: 0x0400014C RID: 332
    public AudioClip aud_Prize;

    // Token: 0x0400014D RID: 333
    public int itemchance;

    // Token: 0x0400014E RID: 334
    public AudioClip aud_AllNotebooks;

    // Token: 0x0400014F RID: 335
    public GameObject principal;

    // Token: 0x04000150 RID: 336
    public GameObject yeet;

    // Token: 0x04000151 RID: 337
    public GameObject nurse;

    // Token: 0x04000152 RID: 338
    public GameObject unnameable;

    // Token: 0x04000153 RID: 339
    public GameObject glitchy;

    // Token: 0x04000154 RID: 340
    public GameObject crafters;

    // Token: 0x04000155 RID: 341
    public GameObject playtime;

    // Token: 0x04000156 RID: 342
    public PlaytimeScript playtimeScript;

    // Token: 0x04000157 RID: 343
    public GameObject gottaSweep;

    // Token: 0x04000158 RID: 344
    public GameObject bully;

    // Token: 0x04000159 RID: 345
    public GameObject firstPrize;

    // Token: 0x0400015A RID: 346
    public FirstPrizeScript firstPrizeScript;

    // Token: 0x0400015B RID: 347
    public GameObject quarter;

    // Token: 0x0400015C RID: 348
    public AudioSource tutorBaldi;

    // Token: 0x0400015D RID: 349
    public AudioSource tutorBaldi2;

    // Token: 0x0400015E RID: 350
    public string mode;

    // Token: 0x0400015F RID: 351
    public int notebooks;

    // Token: 0x04000160 RID: 352
    public GameObject[] notebookPickups;

    // Token: 0x04000161 RID: 353
    public int failedNotebooks;

    // Token: 0x04000162 RID: 354
    public float time;

    // Token: 0x04000163 RID: 355
    public bool spoopMode;

    // Token: 0x04000164 RID: 356
    public bool finaleMode;

    // Token: 0x04000165 RID: 357
    public bool debugMode;

    // Token: 0x04000166 RID: 358
    public bool mouseLocked;

    // Token: 0x04000167 RID: 359
    public int exitsReached;

    // Token: 0x04000168 RID: 360
    public PrincipalScript jazz;

    // Token: 0x04000169 RID: 361
    public int itemSelected;

    // Token: 0x0400016A RID: 362
    public int[] item = new int[3];

    // Token: 0x0400016B RID: 363
    public RawImage[] itemSlot = new RawImage[3];

    // Token: 0x0400016C RID: 364
    private string[] itemNames = new string[]
    {
        "...",
        "Double Chocolate Muffin",
        "Wooden Door Lock",
        "Hair-Pin",
        "R-DRINK",
        "Coupon",
        "Broken Disc",
        "Broken Radio",
        "Silencer",
        "Razor",
        "Blueberry Muffin",
        "Z-Soda",
        "Airhorn",
        "Jake-Permakiller",
        "Jazzy Whistle",
        "Window Key",
        "A Present from Pokki"
    };

    // Token: 0x0400016D RID: 365
    public Text itemText;

    // Token: 0x0400016E RID: 366
    public UnityEngine.Object[] items = new UnityEngine.Object[10];

    // Token: 0x0400016F RID: 367
    public Texture[] itemTextures = new Texture[10];

    // Token: 0x04000170 RID: 368
    public GameObject bsodaSpray;

    // Token: 0x04000171 RID: 369
    public GameObject osodaSpray;

    // Token: 0x04000172 RID: 370
    public GameObject alarmClock;

    // Token: 0x04000173 RID: 371
    public Text notebookCount;

    // Token: 0x04000174 RID: 372
    public GameObject pauseText;

    // Token: 0x04000175 RID: 373
    public GameObject toggleonbutton;

    // Token: 0x04000176 RID: 374
    public GameObject toggleoffbutton;

    // Token: 0x04000177 RID: 375
    public GameObject highScoreText;

    // Token: 0x04000178 RID: 376
    public GameObject baldiNod;

    // Token: 0x04000179 RID: 377
    public GameObject baldiShake;

    // Token: 0x0400017A RID: 378
    public ConveyorScript conveyor;

    // Token: 0x0400017B RID: 379
    public GameObject warning;

    // Token: 0x0400017C RID: 380
    public GameObject reticle;

    // Token: 0x0400017D RID: 381
    public RectTransform itemSelect;

    // Token: 0x0400017E RID: 382
    private int[] itemSelectOffset;

    // Token: 0x0400017F RID: 383
    private bool gamePaused;

    // Token: 0x04000180 RID: 384
    private bool learningActive;

    // Token: 0x04000181 RID: 385
    private float gameOverDelay;

    // Token: 0x04000182 RID: 386
    public AudioSource audioDevice;

    // Token: 0x04000183 RID: 387
    public AudioClip aud_Soda;

    // Token: 0x04000184 RID: 388
    public AudioClip aud_Eat;

    // Token: 0x04000185 RID: 389
    public AudioClip aud_Spray;

    // Token: 0x04000186 RID: 390
    public AudioClip aud_buzz;

    // Token: 0x04000187 RID: 391
    public AudioClip aud_Hang;

    // Token: 0x04000188 RID: 392
    public AudioClip aud_MachineQuiet;

    // Token: 0x04000189 RID: 393
    public AudioClip aud_MachineStart;

    // Token: 0x0400018A RID: 394
    public AudioClip aud_MachineRev;

    // Token: 0x0400018B RID: 395
    public AudioClip aud_MachineLoop;

    // Token: 0x0400018C RID: 396
    public AudioClip aud_Switch;

    // Token: 0x0400018D RID: 397
    public AudioSource schoolMusic;

    // Token: 0x0400018E RID: 398
    public AudioSource learnMusic;

    // Token: 0x0400018F RID: 399
    public AudioClip aud_Horn;

    // Token: 0x04000190 RID: 400
    public BaldiScript jake;

    // Token: 0x04000191 RID: 401
    public GlitchyScript glitch;

    // Token: 0x04000192 RID: 402
    public GameObject madglitchy;

    // Token: 0x04000193 RID: 403
    public SpriteRenderer glitchysprite;

    // Token: 0x04000194 RID: 404
    public RandomEventScript revent;

    // Token: 0x04000195 RID: 405
    public AudioListener deaf;

    // Token: 0x04000196 RID: 406
    public CapsuleCollider playercollider;

    // Token: 0x04000197 RID: 407
    public AudioClip dontworry;

    // Token: 0x04000198 RID: 408
    public WindowScript window;

    // Token: 0x04000199 RID: 409
    public GameObject PranksterEvil;

    // Token: 0x0400019A RID: 410
    public GameObject PranksterEvil1;

    // Token: 0x0400019B RID: 411
    public GameObject PranksterEvil2;

    // Token: 0x0400019C RID: 412
    public GameObject PranksterEvil3;

    // Token: 0x0400019D RID: 413
    public GameObject PranksterEvil4;

    // Token: 0x0400019E RID: 414
    public GameObject PranksterEvil5;

    // Token: 0x0400019F RID: 415
    public GameObject PranksterEvil6;

    // Token: 0x040001A0 RID: 416
    public GameObject PranksterEvil7;

    // Token: 0x040001A1 RID: 417
    public GameObject Prankster8;

    // Token: 0x040001A2 RID: 418
    public GameObject Prankster9;

    // Token: 0x040001A3 RID: 419
    public GameObject Prankster10;

    // Token: 0x040001A4 RID: 420
    public GameObject ExtraNotebook8;

    // Token: 0x040001A5 RID: 421
    public GameObject EXN9;

    // Token: 0x040001A6 RID: 422
    public GameObject EXN10;

    // Token: 0x040001A7 RID: 423
    public RandomEventScript RandomEventScript;
}
