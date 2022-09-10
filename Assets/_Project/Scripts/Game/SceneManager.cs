using System.Collections;
using UnityEngine;

namespace Scripts.Game
{
    public class SceneManager : MonoBehaviour
    {
        private const string SceneName = "SampleScene";
        private const float FailTime = 3.57f;
        private const float DrawTime = 1.3f;

        [SerializeField] private GameObject _failUI;
        [SerializeField] private GameObject _drawlUI;
        [SerializeField] private GameObject _clearUI;
        [SerializeField] private Fail.Fail _platform;
        [SerializeField] private Finish.Finish _finish;

        [SerializeField] private Camera _secondaryCamera;
        [SerializeField] private Camera _mainCamera;

        private void Awake()
        {
            _secondaryCamera.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _platform.PlayerFallen += EnableFailUI;
            _finish.PlayerFinished += EnableFinishUI;
        }

        private void OnDisable()
        {
            _platform.PlayerFallen -= EnableFailUI;
            _finish.PlayerFinished -= EnableFinishUI;
        }

        private void EnableFailUI()
        {
            _failUI.gameObject.SetActive(true);
            StartCoroutine(WaitForFail());
        }

        private void EnableFinishUI()
        {
            _clearUI.gameObject.SetActive(true);
        }

        private void EnableDrawUI()
        {
            _mainCamera.gameObject.SetActive(false);
            _secondaryCamera.gameObject.SetActive(true);
            _failUI.gameObject.SetActive(false);
            _drawlUI.gameObject.SetActive(true);
            StartCoroutine(WaitForDraw());
        }

        private IEnumerator WaitForFail()
        {
            yield return new WaitForSeconds(FailTime);
            EnableDrawUI();
        }

        private IEnumerator WaitForDraw()
        {
            yield return new WaitForSeconds(DrawTime);
            // _mainCamera.gameObject.SetActive(true);
            // _secondaryCamera.gameObject.SetActive(false);
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
        }
    }
}