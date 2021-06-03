using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace Tweening
{
    // public class MainWindowView : MonoBehaviour
    // {
    //     [SerializeField] private Button _openPopupButton;
    //     [SerializeField] private PopupView _popupView;
    //
    //     [SerializeField] private Button _changeTextButton;
    //     [SerializeField] private Text _changeText;
    //
    //     private void Start()
    //     {
    //         _openPopupButton.onClick.AddListener(_popupView.ShowPopup);
    //         _changeTextButton.onClick.AddListener(ChangeText);
    //     }
    //
    //     private void OnDestroy()
    //     {
    //         _openPopupButton.onClick.RemoveAllListeners();
    //         _changeTextButton.onClick.RemoveAllListeners();
    //         _changeText.DOKill();
    //     }
    //
    //     private void ChangeText()
    //     {
    //         _changeText.DOText("New text", 1.0f).SetEase(Ease.Linear);
    //     }
    // }
}