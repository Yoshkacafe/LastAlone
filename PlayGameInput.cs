using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGameInput : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text LoadingText;

    public GameObject mainMenu;
    public GameObject NewGamePart;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            LoadLevel(1);
            mainMenu.SetActive(false);
            NewGamePart.SetActive(false);
        }
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation opreration = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while(!opreration.isDone)
        {
            float progress = Mathf.Clamp01(opreration.progress / 0.9f);

            slider.value = progress;
            Debug.Log(opreration.progress);

            LoadingText.text = progress * 100 + "%";

            yield return null;
        }
    }
}
