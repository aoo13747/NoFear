using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_menu : MonoBehaviour
{
    public GameObject startText;
    float timer;
    bool init;
    public GameObject menuObj;
    void Start()
    {
        Time.timeScale = 1;
        menuObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!init)
        {
            //ตัวกระพริบ press start
            timer += Time.deltaTime;
            if (timer > 0.6f)
            {
                timer = 0;
                startText.SetActive(!startText.activeInHierarchy);
            }
            //ตัวกด space แล้ว เข้าเมนู
            if (Input.GetButtonDown("Fire1"))
            {
                init = true;
                startText.SetActive(false);
                menuObj.SetActive(true); //ตัวปิดข้อความ press start
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log("load");
                }

            }
        }
    }
}

