using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChanger : MonoBehaviour
{
    [Header("UI")]
    public Button OpenCamerabtn;

    [Header("Game Objects")]
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject MainMenu;
    public GameObject imageScanned;

    //[Header("Game Objects")]
    public GameObject vidPrefab;

    void Start()
    {
        OpenCamerabtn.onClick.AddListener(CameraClick);
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        imageScanned.SetActive(false);
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
        imageScanned.SetActive(true);

        Instantiate(vidPrefab, new Vector3(0, .5f, 0), Quaternion.identity);
    }

    public void BackClick()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        MainMenu.SetActive(true);

    }
}
