using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Animator))]

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private TMP_Text LoadingPercentage;
    [SerializeField] private Image LoadingProgressBar;

    private static SceneTransition _instance;
    private static bool _isPlayOpeningAnimation = false;

    private Animator _componentAnimator;
    private AsyncOperation _loadingSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        _instance._componentAnimator.SetTrigger("sceneClosing");
        SceneManager.LoadScene(sceneName);

        _instance._loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        _instance._loadingSceneOperation.allowSceneActivation = false;
    }

    public void AnimationOver()
    {
        _isPlayOpeningAnimation = true;
        _instance._loadingSceneOperation.allowSceneActivation = true;
    }

    private void Start()
    {
        _instance = this;

        _componentAnimator = GetComponent<Animator>();

        if (_isPlayOpeningAnimation)
            _componentAnimator.SetTrigger("sceneOpening");
    }

    private void Update()
    {
        if (_loadingSceneOperation != null)
        {
            LoadingPercentage.text = Mathf.RoundToInt(_loadingSceneOperation.progress * 100) + "%";
            LoadingProgressBar.fillAmount = _loadingSceneOperation.progress;
        }
    }
}
