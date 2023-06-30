using System.Collections;
using Core.ServiceLocator;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LoadingScreenScene
{
    public interface ILoadingScreenService : IService
    {
        UnityEvent LoadingProcessFinished { get; }
        IEnumerator ShowFakeLoadingProcess(TMP_Text progressPercentageText, Slider progressBar);
    }
}
