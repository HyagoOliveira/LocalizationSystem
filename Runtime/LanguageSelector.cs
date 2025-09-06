#if AC_UI_SYSTEM
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using ActionCode.UISystem;

namespace ActionCode.LocalizationSystem
{
    /// <summary>
    /// Use a ListView to display and select any available languages (necessary the ActionCode.UISystem package).
    /// </summary>
    [DefaultExecutionOrder(1)]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ListController))]
    public sealed class LanguageSelector : MonoBehaviour
    {
        [SerializeField, Tooltip("The local List Controller component.")]
        private ListController languageList;

        [Space]
        [Tooltip("Event fired when the localization is selected.")] public UnityEvent OnLangugeConfirmed;

        private void Reset() => languageList = GetComponent<ListController>();

        private void OnEnable()
        {
            SubscribeEvents();
            PopulateLanguagesListAsync();
        }

        private void OnDisable() => UnsubscribeEvents();

        private void SubscribeEvents()
        {
            languageList.GetItemName = GetLanguageName;
            languageList.GetItemText = GetLanguageText;
            languageList.OnItemSelected += HandleLanguageSelected;
            languageList.OnItemConfirmed += HandleLanguageConfirmed;
        }

        private void UnsubscribeEvents()
        {
            languageList.GetItemName = null;
            languageList.GetItemText = null;
            languageList.OnItemSelected -= HandleLanguageSelected;
            languageList.OnItemConfirmed -= HandleLanguageConfirmed;
        }

        private void HandleLanguageSelected(object item) => LocalizationManager.Select(item as Locale);

        private void HandleLanguageConfirmed(object _)
        {
            languageList.Delete();
            OnLangugeConfirmed?.Invoke();
        }

        private string GetLanguageText(object item) => LocalizationManager.GetDisplayName(item as Locale);
        private string GetLanguageName(object item) => (item as Locale).Identifier.Code;

        private async void PopulateLanguagesListAsync()
        {
            var locales = await LocalizationManager.GetLocalesAsync();
            var index = LocalizationManager.GetLocaleIndex(locales);
            languageList.SetSource(locales, index);
        }
    }
}
#endif