using System;
using System.Collections;
using UnityEngine;

namespace Scripts.DrawPath
{
    public class AutoDraw : MonoBehaviour
    {
        [SerializeField] private Path _pathTemplate;

        private readonly PointSetting[][] _pointSettings = new PointSetting[9][];

        private void Start()
        {
            FillPointSettings();
            StartCoroutine(AutoDrawing());
        }

        private void FillPointSettings()
        {
            _pointSettings[0] = new[]

            {
                new PointSetting(new Vector3(3.279f, 81.665f, 0), 1.39f),
                new PointSetting(new Vector3(-2.55f, 90.546f, 0), 1.573f),
                new PointSetting(new Vector3(-2.068f, 89.489f, 0), 1.63f),
                new PointSetting(new Vector3(-1.496f, 88.426f, 0), 1.687f),
                new PointSetting(new Vector3(-0.958f, 87.208f, 0), 1.738f),
                new PointSetting(new Vector3(-0.454f, 85.752f, 0), 1.796f),
                new PointSetting(new Vector3(-0.023f, 84.167f, 0), 1.85f),
                new PointSetting(new Vector3(0.291f, 82.714f, 0), 1.901f),
                new PointSetting(new Vector3(0.655f, 81.181f, 0), 1.955f),
                new PointSetting(new Vector3(0.94f, 79.613f, 0), 2.005f),
                new PointSetting(new Vector3(1.323f, 77.721f, 0), 2.062f),
                new PointSetting(new Vector3(1.587f, 75.928f, 0), 2.12f),
                new PointSetting(new Vector3(1.825f, 73.688f, 0), 2.178f),
                new PointSetting(new Vector3(1.942f, 71.279f, 0), 2.237f),
                new PointSetting(new Vector3(1.93f, 68.689f, 0), 2.295f),
                new PointSetting(new Vector3(1.817f, 66.126f, 0), 2.351f),
                new PointSetting(new Vector3(1.502f, 63.826f, 0), 2.407f),
                new PointSetting(new Vector3(1.011f, 61.875f, 0), 2.457f),
                new PointSetting(new Vector3(0.405f, 59.765f, 0), 2.516f),
                new PointSetting(new Vector3(-0.461f, 57.727f, 0), 2.575f),
                new PointSetting(new Vector3(-1.344f, 56.077f, 0), 2.628f),
                new PointSetting(new Vector3(-2.438f, 54.452f, 0), 2.683f),
                new PointSetting(new Vector3(-3.632f, 53.173f, 0), 2.736f),
                new PointSetting(new Vector3(-6.406f, 51.85f, 0), 2.794f),
            };
        }

        private IEnumerator AutoDrawing()
        {
            foreach (var array in _pointSettings)
            {
                var path = Instantiate(_pathTemplate, transform.position, Quaternion.identity, transform);

                foreach (var settings in array)
                {
                    yield return new WaitForSeconds(settings.Time - Time.time);
                    path.AddMainPoint(settings.Position);
                }
            }
        }
    }
}