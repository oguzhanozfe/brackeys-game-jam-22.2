using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject sideDog;

    public int x;

    private Vector3 play = new Vector3(235, -85, 0);
    private Vector3 sound = new Vector3(235, -270, 0);
    private Vector3 exit = new Vector3(235, -445, 0);
    private float detector;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void onAwake()
    {
        sideDog.transform.position = play;
    }

    public void Update()
    {
        detector = Input.mousePosition.y;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (detector > 750-x)
        {
            sideDog.transform.localPosition = play;
        }
        else if (detector < 750-x && detector > 600-x)
        {
            sideDog.transform.localPosition = sound;
        }
        else if (detector < 600-x)
        {
            sideDog.transform.localPosition = exit;
        }

        Debug.Log("Pointer Enter");

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");
    }
}
