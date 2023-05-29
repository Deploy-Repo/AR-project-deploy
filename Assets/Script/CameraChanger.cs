using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChanger : MonoBehaviour
{
    public Button OpenCamerabtn;

    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject MainMenu;


    void Start()
    {
        OpenCamerabtn.onClick.AddListener(CameraClick);
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        MainMenu.SetActive(true);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackClick();
        }
    }

    public void CameraClick()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(true);
        MainMenu.SetActive(false);

    }

    public void BackClick()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        MainMenu.SetActive(true);

    }
}
