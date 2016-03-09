using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuButton : MonoBehaviour {

    void OnMouseDown()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
